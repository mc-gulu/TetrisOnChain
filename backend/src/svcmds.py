
import os
import sys
import time
import logging

import toml
from docopt import docopt
from bitsv.network import NetworkAPI

import consts

from svwallet import SVWallet, get_addr_filename
# from dot_smallpay import dot_engrave

import svlet.net

NETWORK = "main" # main/test/stn

# 取现最多允许热钱包内的百分比 (默认 50%)
WITHDRAW_MAX_PERCENT = 50

def _uni_out(str, newline = False):
    sys.stdout.write(str + (newline and '\n' or ''))
    logging.info(str)

def _err_out(str, newline = False):
    sys.stderr.write(str + (newline and '\n' or ''))
    logging.info(str)


def _verify_auth_exists(args):
    if not args['--name']:
        raise Exception("wallet name is empty.")
    if not args['--pass']:
        raise Exception("wallet '{}' password is empty.".format(args['--name']))
    pass

def _load_wallet_from_args(args):
    _verify_auth_exists(args)

    w = SVWallet(args['--network'] or NETWORK)
    w.load(args['--name'], args['--pass'])
    return w

def new_wallet(args):
    _verify_auth_exists(args)

    sw = SVWallet(args['--network'] or NETWORK)
    sw.save(args['--name'], args['--pass'])
    # sw.printvalues()

    # verifying
    wl = _load_wallet_from_args(args)
    assert sw.getaddress() == wl.getaddress()


def get_balance(args):
    logging.info("TODO: svcmds.get_balance() 应该改为使用更健壮的 API 实现")
    
    if args['--addr']:
        # get balance with address only
        network_api = NetworkAPI(args['--network'] or NETWORK)
        unspents = network_api.get_unspents(args['--addr'])
        sys.stdout.write(str(sum(unspent.amount for unspent in unspents)))
    else:
        # get balance through wallet
        w = _load_wallet_from_args(args)
        sys.stdout.write(w.getbalance())


def transfer_to(args):
    w = _load_wallet_from_args(args)
    txid = w.sendtx(args['--destaddr'], args['--satoshi'])
    sys.stdout.write(txid)


# --- advanced features ---

def triple_new(args):
    _verify_auth_exists(args)
    if not args['--coldpass']:
        raise Exception("wallet '{}': cold wallet password not found, which should be specified separately.".format(args['--name']))

    network = args['--network'] or NETWORK
    mw = SVWallet(network)
    mw.save(args['--name'] + "_mw", args['--pass'])
    hw = SVWallet(network)
    hw.save(args['--name'] + "_hw", args['--pass'])
    cw = SVWallet(network)
    cw.save(args['--name'] + "_cw", args['--coldpass'])


def triple_status(args):
    _verify_auth_exists(args)

    mw = SVWallet(args['--network'] or NETWORK)
    mw.load(args['--name'] + "_mw", args['--pass'])
    hw = SVWallet(args['--network'] or NETWORK)
    hw.load(args['--name'] + "_hw", args['--pass'])
    _uni_out("wallet '{}' balance: merchant={}, hot={}".format(args['--name'], mw.getbalance(), hw.getbalance()))

def triple_conflate(args):
    _verify_auth_exists(args)

    w = SVWallet(args['--network'] or NETWORK)
    w.load(args['--name'] + "_mw", args['--pass'])

    current = int(w.getbalance())
    if current < consts.CONFLATE_THRESHOLD:
        sys.stderr.write('balance less than threshold. (current: {}, expected: {})'.format(current, consts.CONFLATE_THRESHOLD))
        return

    to_hot = int((current - consts.CONFLATE_SAT_LEFT) * consts.CONFLATE_HOT_RATIO)
    to_cold = int((current - consts.CONFLATE_SAT_LEFT) * (1 - consts.CONFLATE_HOT_RATIO))
    logging.info('conflate: current: {} (to_hot: {}, to_cold: {})\n'.format(current, to_hot, to_cold))

    hot_addr = ""
    with open(get_addr_filename(args['--name'] + "_hw"), 'r') as f:
        hot_addr = f.read()

    cold_addr = ""
    with open(get_addr_filename(args['--name'] + "_cw"), 'r') as f:
        cold_addr = f.read()
    
    # sys.stdout.write("""
    # conflation (pre-execution):
    #     current: {}
    #         to_hot ('{}'): {}
    #         to_cold ('{}'): {}
    #         remains: {}
    # """.format(current, hot_addr, to_hot, cold_addr, to_cold, int(current - to_hot - to_cold)))

    txid = w.sendtx_for_2(hot_addr, to_hot, cold_addr, to_cold)

    # sys.stdout.write("""
    # conflation (post-execution):
    #     txid: {}
    #     remains: {}
    # """.format(txid, w.getbalance()))

    sys.stdout.write(txid)


def triple_withdraw(args):
    _verify_auth_exists(args)

    w = SVWallet(args['--network'] or NETWORK)
    w.load(args['--name'] + "_hw", args['--pass'])

    withdrawAddr = args["--destaddr"]
    if not withdrawAddr:
        _err_out('#ERR "--destaddr" is empty.')
        return

    withdrawAmount = int(args['--satoshi'])
    balance = int(w.getbalance())
    if withdrawAmount >= int(balance * (WITHDRAW_MAX_PERCENT / 100)):
        _err_out('#ERR balance not enough. ({}/{}, {}%)'.format(withdrawAmount, balance, int(withdrawAmount / balance * 100)))
        return

    # sys.stdout.write("triple_withdraw (p1): balance: {}\n".format(balance))
    txid = w.sendtx(withdrawAddr, withdrawAmount)
    # sys.stdout.write("triple_withdraw (p2): txid: {}\n".format(txid))

    # sys.stdout.write("triple_withdraw (p3): balance: {}\n".format(w.getbalance()))
    # time.sleep(5)
    # sys.stdout.write("triple_withdraw (p4): balance (waited): {}\n".format(w.getbalance()))
    sys.stdout.write(txid)
    logging.info("witdraw done. txid={}".format(txid))


# = tx_opreturn = 从指定的私钥发出一笔 opreturn 的交易
def tx_opreturn(args):
    # logging.info('foo: {}, {}'.format(args['--wif'], args['<opreturn_data>']))

    # load WIF (or using the default one in config file)
    wif = ""
    if args['--wif']:
        wif = args['--wif']
    else:
        cfg = toml.load('cfg.toml')
        assert 'default_wif' in cfg['data_engraving']
        wif = cfg['data_engraving']['default_wif']

    # create a wallet using the given WIF
    w = SVWallet(args['--network'] or NETWORK)
    w.load_wif(wif)

    # split the satoplay prefix
    content = args['<opreturn_data>']
    logging.info("(opreturn) pre-process: {}".format(content))
    if len(content) == 1:
        data = content[0].split(',', 1)
        if data[0] == "satoplay.com":
            content = data
    logging.info("(opreturn) post-process: {}".format(content))

    # 参数 feeMode
    feeMode = "relay"
    if args['--fee_mode']:
        feeMode = args['--fee_mode']

    # 参数 from_txid
    specified_txid = None
    if args['--from_txid']:
        specified_txid = args['--from_txid']

    tx_hex = w.create_opreturn_tx_with_content(content, feeMode, from_txid=specified_txid)
    if not tx_hex:
        raise Exception("tx creating failed. (see logs for details)")

    target = "metasv"
    if args['--target']:
        target = args['--target']

    txid = svlet.net.mapi_sendtx(tx_hex, target)
    sys.stdout.write(txid)
    logging.info('sending tx: {} (fee_mode={}, target={})'.format(txid, feeMode, target))



def query_utxo_set(args):
    """ 查询 utxo 集 """
    # load WIF (or using the default one in config file)
    wif = ""
    if args['--wif']:
        wif = args['--wif']
    else:
        cfg = toml.load('cfg.toml')
        assert 'default_wif' in cfg['data_engraving']
        wif = cfg['data_engraving']['default_wif']

    # create a wallet using the given WIF
    w = SVWallet(args['--network'] or NETWORK)
    w.load_wif(wif)
    utxos = w.get_unspents()
    for u in utxos:
        sys.stdout.write(u.txid)
        sys.stdout.write(',')
        