import sys
import json
import pprint
import sseclient
import traceback

from requests_toolbelt.utils import dump

def with_urllib3(url):
    """Get a streaming response for the given event feed using urllib3."""
    import urllib3
    http = urllib3.PoolManager()
    return http.request('GET', url, preload_content=False)

def with_requests(url):
    """Get a streaming response for the given event feed using requests."""
    import requests
    return requests.get(url, stream=True)

import threading
import time
import queue

BUF_SIZE = 128

def _cat_url(tx_type=None):
    if tx_type:
        return "https://api.metasv.com/v1/stream/data?p3=satetris&p4={}".format(tx_type)
    else:
        return "https://api.metasv.com/v1/stream/data?p3=satetris"

class SSEThread(threading.Thread):
    def __init__(self):
        super(SSEThread, self).__init__()
        self._tx_type = None
        self.daemon = True # 主线程退出时，这个线程能自动退出
        self._evtQueue = queue.Queue(BUF_SIZE)
        self._url = _cat_url(self._tx_type or None)

    def setTxType(self, tx_type):
        self._tx_type = tx_type

    def hasEvent(self):
        return not self._evtQueue.empty() 

    def getEvent(self):
        # print("(daemon) evt queue size: ", self._evtQueue.qsize())
        evt = self._evtQueue.get_nowait() 
        # print("(daemon) evt queue size: ", self._evtQueue.qsize())
        return evt

    def run(self):
        # response = with_urllib3(self._url)
        response = with_requests(self._url)
        client = sseclient.SSEClient(response)

        for event in client.events():
            try:
                evt = json.loads(event.data)
                if 'type' not in evt:
                    print("(daemon) bad event ('type' field missing): ", pprint.pformat(evt))
                    continue

                if evt['type'] != "DATA":
                    print("(daemon) routine event: ", pprint.pformat(evt))
                    continue

                # pprint.pprint(evt)
                # print("(daemon) evt queue size: ", self._evtQueue.qsize())
                self._evtQueue.put_nowait(evt['data'])
                # print("(daemon) evt queue size: ", self._evtQueue.qsize())

            except Exception as e:
                print("(daemon) event Exception: ", e)
                
