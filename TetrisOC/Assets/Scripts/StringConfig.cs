using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringConfig
{
    public static string[] LoginStateString =
    {
        "流程开启",
        "获取版本信息",
        "更新资源",
        "加载数据表",
        "读取动态配置",
        "读取游戏公告",
        "校对时间",
        "登录",
        "获取玩家数据",
        "补全玩家数据",
        "校对日期",
        "拉取公共邮件",
        "完成",
    };
    /*
        Start,//开始流程
        VersionJson,//下载VersionJson文件
        Update,//热更新
        TableData,//加载数据表
        ServerConfig,//读取动态配置
        ServerNotice,//读取游戏公告
        TimeDate,//同步时间日期
        Login,//登录
        LoadAllData,//获取玩家数据
        FillData,//补全初始玩家数据
        UPDATE_DAYS,
        LoadMail,//拉取公共邮件
        // Replenishment,//商城检测、补单
        Finish,*/
    public const string Tips_Text_NoResources = "缺少{0}";//缺少金币、钻石

    static Dictionary<int, string> errortable = new Dictionary<int, string>();
    public static Dictionary<int, string> ErrorDict
    {
        get
        {
            if (errortable.Count == 0)
            {
                errortable[-1001] = "电池不足";
            }
            return errortable;
        }
    }

    //邮箱
    //有补偿按钮
    public const string PostButtonTextWithDropID = "receive";
    //无补偿按钮
    public const string PostButtonTextWithNoDropID = "got_it";
    //邮件已删除
    public const string PostHaveDelete = "e-mail_deleted";

    //提示
    public const string Tips_Title = "tips";
    public const string Tips_Low_Version = "low_version";
    public const string HeroBagMax = "英雄背包已满，请合成英雄";//英雄已满


    //广告抽奖剩余次数
    public const string LotteryLeftCount = "今日免费单抽还剩{0}次";
    //十连抽橙卡概率
    public const string LotteryBetterPercent = "获得史诗卡的概率提升至{0:P1}";

    //每秒产金币
    public const string PerSecond = "{0}/秒";

}