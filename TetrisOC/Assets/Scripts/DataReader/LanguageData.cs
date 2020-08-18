using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class LanguageData{
/// <summary>
/// 原文本
/// </summary>
public string key;
/// <summary>
/// 默认文本
/// </summary>
public string def;
/// <summary>
/// 英文
/// </summary>
public string english;
/// <summary>
/// 中文
/// </summary>
public string chinese;
/// <summary>
/// 繁体
/// </summary>
public string traditionalchinese;
public LanguageData(string key, string def, string english, string chinese, string traditionalchinese){
this.key = key;
this.def = def;
this.english = english;
this.chinese = chinese;
this.traditionalchinese = traditionalchinese;
}
class LanguageDataReader{
static LanguageDataReader instance;
static object syncRoot = new object();
public static LanguageDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new LanguageDataReader();instance.Load();}}}return instance;}}
Dictionary<string, LanguageData> root = new Dictionary<string, LanguageData>();
void Load(){
root.Add("taptostart", new LanguageData("taptostart", "", "Tap to start", "点击开始", "點擊開始"));
root.Add("privacy_policy_text", new LanguageData("privacy_policy_text", "", "I have read and agreed to the <color=#49ecff> Privacy Policy</color>", "我已详细阅读并同意<color=#49ecff> 隐私保护协议</color>", "我已詳細閱讀並同意<color=#49ecff> 隱私保護協議</color>"));
root.Add("privacy_policy_error", new LanguageData("privacy_policy_error", "", "You need to agree to the <color=#49ecff> Privacy Policy</color> before playing", "您需要同意<color=#49ecff> 隐私保护协议</color>才能游玩", "您需要同意<color=#49ecff> 隱私保護協議</color>才能遊玩"));
root.Add("tutorial_text1", new LanguageData("tutorial_text1", "", "tap to pick up the coin", "点击回收金币", "点击回收金币"));
root.Add("tutorial_text2", new LanguageData("tutorial_text2", "", "", "再点再收", ""));
root.Add("tutorial_text3", new LanguageData("tutorial_text3", "", "", "哇，这回发财了", ""));
root.Add("AUTO", new LanguageData("AUTO", "", "AUTO", "自动", ""));
root.Add("CONTINUE", new LanguageData("CONTINUE", "", "CONTINUE", "继续", ""));
root.Add("GIVE UP", new LanguageData("GIVE UP", "", "GIVE UP", "放弃", ""));
root.Add("FAILURE", new LanguageData("FAILURE", "", "FAILURE", "失败", ""));
root.Add("INCREASED CHARACTER STRENGTH", new LanguageData("INCREASED CHARACTER STRENGTH", "", "INCREASED CHARACTER STRENGTH", "提升角色等级能有效帮助通关", ""));
root.Add("VICTORY", new LanguageData("VICTORY", "", "VICTORY", "胜利", ""));
root.Add("BATTLE DATA", new LanguageData("BATTLE DATA", "", "BATTLE DATA", "战斗数据统计", ""));
root.Add("DAMAGE", new LanguageData("DAMAGE", "", "DAMAGE", "攻击输出", ""));
root.Add("GETDAM", new LanguageData("GETDAM", "", "GETDAM", "承受伤害", ""));
root.Add("HEALING", new LanguageData("HEALING", "", "HEALING", "治愈量", ""));
root.Add("HERO", new LanguageData("HERO", "", "HERO", "英雄", ""));
root.Add("REWARD", new LanguageData("REWARD", "", "REWARD", "奖励", ""));
root.Add("home", new LanguageData("home", "", "home", "返回主城", ""));
root.Add("double_prize", new LanguageData("double_prize", "", "double_prize", "双倍奖励", ""));
root.Add("check_in_title", new LanguageData("check_in_title", "", "CHECK IN", "签到", ""));
root.Add("have_got", new LanguageData("have_got", "", "", "已领取", ""));
root.Add("not_ready", new LanguageData("not_ready", "", "", "待领取", ""));
root.Add("get_item", new LanguageData("get_item", "", "", "领取", ""));
root.Add("Lv up", new LanguageData("Lv up", "", "Lv up", "升级", ""));
root.Add("Close", new LanguageData("Close", "", "Close", "关闭", ""));
root.Add("skip", new LanguageData("skip", "", "skip", "点击跳过", ""));
root.Add("s800101", new LanguageData("s800101", "", "", "火刀锋", ""));
root.Add("s800201", new LanguageData("s800201", "", "", "风刀锋", ""));
root.Add("s800301", new LanguageData("s800301", "", "", "水刀锋", ""));
root.Add("s800401", new LanguageData("s800401", "", "", "光刀锋", ""));
root.Add("s800501", new LanguageData("s800501", "", "", "暗刀锋", ""));
root.Add("s800601", new LanguageData("s800601", "", "", "火旋转", ""));
root.Add("s800701", new LanguageData("s800701", "", "", "风旋转", ""));
root.Add("s800801", new LanguageData("s800801", "", "", "水旋转", ""));
root.Add("s800901", new LanguageData("s800901", "", "", "光旋转", ""));
root.Add("s801001", new LanguageData("s801001", "", "", "暗旋转", ""));
root.Add("s801101", new LanguageData("s801101", "", "", "火箭", ""));
root.Add("s801201", new LanguageData("s801201", "", "", "风箭", ""));
root.Add("s801301", new LanguageData("s801301", "", "", "水箭", ""));
root.Add("s801401", new LanguageData("s801401", "", "", "光箭", ""));
root.Add("s801501", new LanguageData("s801501", "", "", "暗箭", ""));
root.Add("s801601", new LanguageData("s801601", "", "", "微弱火星", ""));
root.Add("s801701", new LanguageData("s801701", "", "", "微弱风弹", ""));
root.Add("s801801", new LanguageData("s801801", "", "", "微弱水弹", ""));
root.Add("s801901", new LanguageData("s801901", "", "", "微弱光点", ""));
root.Add("s802001", new LanguageData("s802001", "", "", "微弱暗点", ""));
root.Add("s802101", new LanguageData("s802101", "", "", "火球", ""));
root.Add("s802201", new LanguageData("s802201", "", "", "风球", ""));
root.Add("s802301", new LanguageData("s802301", "", "", "水球", ""));
root.Add("s802401", new LanguageData("s802401", "", "", "光球", ""));
root.Add("s802501", new LanguageData("s802501", "", "", "暗球", ""));
root.Add("s802601", new LanguageData("s802601", "", "", "火红药瓶子", ""));
root.Add("s802701", new LanguageData("s802701", "", "", "风药瓶子", ""));
root.Add("s802801", new LanguageData("s802801", "", "", "水药瓶子", ""));
root.Add("s802901", new LanguageData("s802901", "", "", "光药瓶子", ""));
root.Add("s803001", new LanguageData("s803001", "", "", "暗药瓶子", ""));
root.Add("s803101", new LanguageData("s803101", "", "", "火子弹", ""));
root.Add("s803201", new LanguageData("s803201", "", "", "风子弹", ""));
root.Add("s803301", new LanguageData("s803301", "", "", "水子弹", ""));
root.Add("s803401", new LanguageData("s803401", "", "", "光子弹", ""));
root.Add("s803501", new LanguageData("s803501", "", "", "暗子弹", ""));
root.Add("s810101", new LanguageData("s810101", "", "", "流水二连砍", ""));
root.Add("s810201", new LanguageData("s810201", "", "", "半月刀锋", ""));
root.Add("s810301", new LanguageData("s810301", "", "", "自我回复", ""));
root.Add("s810401", new LanguageData("s810401", "", "", "血怒", ""));
root.Add("s810501", new LanguageData("s810501", "", "", "疾风二连斩", ""));
root.Add("s810601", new LanguageData("s810601", "", "", "生命恢复", ""));
root.Add("s810701", new LanguageData("s810701", "", "", "极光斩", ""));
root.Add("s810801", new LanguageData("s810801", "", "", "暴怒", ""));
root.Add("s810901", new LanguageData("s810901", "", "", "风暴之刃", ""));
root.Add("s811001", new LanguageData("s811001", "", "", "蓄力攻击", ""));
root.Add("s811101", new LanguageData("s811101", "", "", "火柱痛击", ""));
root.Add("s811201", new LanguageData("s811201", "", "", "水刃", ""));
root.Add("s811301", new LanguageData("s811301", "", "", "横扫", ""));
root.Add("s811401", new LanguageData("s811401", "", "", "回旋砍击", ""));
root.Add("s811501", new LanguageData("s811501", "", "", "回复之诗", ""));
root.Add("s811601", new LanguageData("s811601", "", "", "单体攻击", ""));
root.Add("s811701", new LanguageData("s811701", "", "", "单体防御", ""));
root.Add("s811801", new LanguageData("s811801", "", "", "单体攻速", ""));
root.Add("s811901", new LanguageData("s811901", "", "", "单体暴击", ""));
root.Add("s812001", new LanguageData("s812001", "", "", "火柱术", ""));
root.Add("s812101", new LanguageData("s812101", "", "", "冰锥", ""));
root.Add("s812201", new LanguageData("s812201", "", "", "光波术", ""));
root.Add("s812301", new LanguageData("s812301", "", "", "弹跳火柴", ""));
root.Add("s812401", new LanguageData("s812401", "", "", "冰锥术，范围击退", ""));
root.Add("s812501", new LanguageData("s812501", "", "", "连续风球追踪", ""));
root.Add("s812601", new LanguageData("s812601", "", "", "连续光波追踪，击中致盲", ""));
root.Add("s812701", new LanguageData("s812701", "", "", "诅咒飞弹，击中减防", ""));
root.Add("s812801", new LanguageData("s812801", "", "", "二连矢", ""));
root.Add("s812901", new LanguageData("s812901", "", "", "穿透箭", ""));
root.Add("s813001", new LanguageData("s813001", "", "", "爆炸射击", ""));
root.Add("s813101", new LanguageData("s813101", "", "", "三连矢", ""));
root.Add("s813201", new LanguageData("s813201", "", "", "穿透箭", ""));
root.Add("s813301", new LanguageData("s813301", "", "", "爆炸箭", ""));
root.Add("s813401", new LanguageData("s813401", "", "", "爆裂光芒", ""));
root.Add("s813501", new LanguageData("s813501", "", "", "重击", ""));
root.Add("s813601", new LanguageData("s813601", "", "", "冰冻手雷", ""));
root.Add("s813701", new LanguageData("s813701", "", "", "燃烧弹", ""));
root.Add("s813801", new LanguageData("s813801", "", "", "快速拔枪", ""));
root.Add("s813901", new LanguageData("s813901", "", "", "三连爆炸射击", ""));
root.Add("s814001", new LanguageData("s814001", "", "", "快速装填", ""));
root.Add("s814101", new LanguageData("s814101", "", "", "重金属单头", ""));
root.Add("s815101", new LanguageData("s815101", "", "", "防御机制I", ""));
root.Add("s815201", new LanguageData("s815201", "", "", "荆棘护甲ILv.1", ""));
root.Add("s815301", new LanguageData("s815301", "", "", "自我防护Lv.1", ""));
root.Add("s815401", new LanguageData("s815401", "", "", "嘲讽Lv.1", ""));
root.Add("s815501", new LanguageData("s815501", "", "", "团队防护Lv.1", ""));
root.Add("s815601", new LanguageData("s815601", "", "", "推开Lv.1", ""));
root.Add("s815701", new LanguageData("s815701", "", "", "天引Lv.1", ""));
root.Add("s815801", new LanguageData("s815801", "", "", "狂怒挥击Lv.1", ""));
root.Add("s815901", new LanguageData("s815901", "", "", "冲撞Lv.1", ""));
root.Add("s816001", new LanguageData("s816001", "", "", "烈风回旋Lv.1", ""));
root.Add("s816101", new LanguageData("s816101", "", "", "血之渴望Lv.1", ""));
root.Add("s816201", new LanguageData("s816201", "", "", "水刃回旋Lv.1", ""));
root.Add("s816301", new LanguageData("s816301", "", "", "血怒之手Lv.1", ""));
root.Add("s816401", new LanguageData("s816401", "", "", "野蛮咆哮Lv.1", ""));
root.Add("s816501", new LanguageData("s816501", "", "", "回复之诗Lv.1", ""));
root.Add("s816601", new LanguageData("s816601", "", "", "力量的赞歌Lv1", ""));
root.Add("s816701", new LanguageData("s816701", "", "", "回复小调", ""));
root.Add("s816801", new LanguageData("s816801", "", "", "回复天颂Lv.1", ""));
root.Add("s816901", new LanguageData("s816901", "", "", "回复天颂Lv.1", ""));
root.Add("s817001", new LanguageData("s817001", "", "", "坚韧的赞歌Lv.1", ""));
root.Add("s817101", new LanguageData("s817101", "", "", "灵感之诗", ""));
root.Add("s817201", new LanguageData("s817201", "", "", "单体回复Lv.1", ""));
root.Add("s817301", new LanguageData("s817301", "", "", "毒药攻击Lv.1", ""));
root.Add("s817401", new LanguageData("s817401", "", "", "回复药剂Lv.1", ""));
root.Add("s817501", new LanguageData("s817501", "", "", "力量药剂Lv.1", ""));
root.Add("s817601", new LanguageData("s817601", "", "", "防御药剂Lv.1", ""));
root.Add("s817701", new LanguageData("s817701", "", "", "清醒药剂Lv.1", ""));
root.Add("s817801", new LanguageData("s817801", "", "", "腐蚀药剂Lv.1", ""));
root.Add("s817901", new LanguageData("s817901", "", "", "火龙卷Lv.1", ""));
root.Add("s818001", new LanguageData("s818001", "", "", "霜冻新星Lv.1", ""));
root.Add("s818101", new LanguageData("s818101", "", "", "龙卷风Lv.1", ""));
root.Add("s818201", new LanguageData("s818201", "", "", "陨石术Lv.1", ""));
root.Add("s818301", new LanguageData("s818301", "", "", "暴风雪Lv.1", ""));
root.Add("s818401", new LanguageData("s818401", "", "", "狂风术Lv.1", ""));
root.Add("s818501", new LanguageData("s818501", "", "", "激光Lv.1", ""));
root.Add("s818601", new LanguageData("s818601", "", "", "召唤黑洞Lv.1", ""));
root.Add("s818701", new LanguageData("s818701", "", "", "蓄力箭Lv.1", ""));
root.Add("s818801", new LanguageData("s818801", "", "", "连射击退Lv.1", ""));
root.Add("s818901", new LanguageData("s818901", "", "", "铁蒺藜Lv.1", ""));
root.Add("s819001", new LanguageData("s819001", "", "", "爆炸箭Lv.1", ""));
root.Add("s819101", new LanguageData("s819101", "", "", "箭雨Lv.1", ""));
root.Add("s819201", new LanguageData("s819201", "", "", "狙击姿态Lv.1", ""));
root.Add("s819301", new LanguageData("s819301", "", "", "魔法箭Lv.1", ""));
root.Add("s819401", new LanguageData("s819401", "", "", "暴雨将至Lv.1", ""));
root.Add("s819501", new LanguageData("s819501", "", "", "爆头Lv.1", ""));
root.Add("s819601", new LanguageData("s819601", "", "", "烈酒Lv.1", ""));
root.Add("s819701", new LanguageData("s819701", "", "", "暴雨将至2Lv.1", ""));
root.Add("s819801", new LanguageData("s819801", "", "", "爆头2Lv.1", ""));
root.Add("s819901", new LanguageData("s819901", "", "", "烈酒2Lv.1", ""));
root.Add("s820001", new LanguageData("s820001", "", "", "猛烈装填Lv.1", ""));
root.Add("s900101", new LanguageData("s900101", "", "", "boss近战", ""));
root.Add("s900201", new LanguageData("s900201", "", "", "吠", ""));
root.Add("s900301", new LanguageData("s900301", "", "", "撕咬", ""));
root.Add("s900401", new LanguageData("s900401", "", "", "高射炮", ""));
root.Add("s900501", new LanguageData("s900501", "", "", "穿刺攻击", ""));
root.Add("s900601", new LanguageData("s900601", "", "", "怪物刀砍", ""));
root.Add("s900701", new LanguageData("s900701", "", "", "爆弹爆炸", ""));
root.Add("s900801", new LanguageData("s900801", "", "", "撞击", ""));
root.Add("s900901", new LanguageData("s900901", "", "", "怪物平A单个2s", ""));
root.Add("s901001", new LanguageData("s901001", "", "", "怪物平A一堆2s", ""));
root.Add("s901101", new LanguageData("s901101", "", "", "怪物平A单个1s", ""));
root.Add("s901201", new LanguageData("s901201", "", "", "怪物平A一堆1s", ""));
root.Add("s901301", new LanguageData("s901301", "", "", "怪物火箭", ""));
root.Add("s901401", new LanguageData("s901401", "", "", "怪物风箭", ""));
root.Add("s901501", new LanguageData("s901501", "", "", "怪物水箭", ""));
root.Add("s901601", new LanguageData("s901601", "", "", "怪物光箭", ""));
root.Add("s901701", new LanguageData("s901701", "", "", "怪物暗箭", ""));
root.Add("s901801", new LanguageData("s901801", "", "", "近战怪系数1", ""));
root.Add("s901901", new LanguageData("s901901", "", "", "近战怪系数0.9", ""));
root.Add("s902001", new LanguageData("s902001", "", "", "近战怪系数0.8", ""));
root.Add("s902101", new LanguageData("s902101", "", "", "近战怪系数0.7", ""));
root.Add("s902201", new LanguageData("s902201", "", "", "近战怪系数0.6", ""));
root.Add("s902301", new LanguageData("s902301", "", "", "近战怪系数0.5", ""));
root.Add("s902401", new LanguageData("s902401", "", "", "近战怪系数0.4", ""));
root.Add("s902501", new LanguageData("s902501", "", "", "近战怪系数0.3", ""));
root.Add("s902601", new LanguageData("s902601", "", "", "近战怪系数0.2", ""));
root.Add("s902701", new LanguageData("s902701", "", "", "近战怪系数0.1", ""));
root.Add("s800101des", new LanguageData("s800101des", "", "", "火刀锋的描述", ""));
root.Add("s800201des", new LanguageData("s800201des", "", "", "风刀锋的描述", ""));
root.Add("s800301des", new LanguageData("s800301des", "", "", "水刀锋的描述", ""));
root.Add("s800401des", new LanguageData("s800401des", "", "", "光刀锋的描述", ""));
root.Add("s800501des", new LanguageData("s800501des", "", "", "暗刀锋的描述", ""));
root.Add("s800601des", new LanguageData("s800601des", "", "", "火旋转的描述", ""));
root.Add("s800701des", new LanguageData("s800701des", "", "", "风旋转的描述", ""));
root.Add("s800801des", new LanguageData("s800801des", "", "", "水旋转的描述", ""));
root.Add("s800901des", new LanguageData("s800901des", "", "", "光旋转的描述", ""));
root.Add("s801001des", new LanguageData("s801001des", "", "", "暗旋转的描述", ""));
root.Add("s801101des", new LanguageData("s801101des", "", "", "火箭的描述", ""));
root.Add("s801201des", new LanguageData("s801201des", "", "", "风箭的描述", ""));
root.Add("s801301des", new LanguageData("s801301des", "", "", "水箭的描述", ""));
root.Add("s801401des", new LanguageData("s801401des", "", "", "光箭的描述", ""));
root.Add("s801501des", new LanguageData("s801501des", "", "", "暗箭的描述", ""));
root.Add("s801601des", new LanguageData("s801601des", "", "", "微弱火星的描述", ""));
root.Add("s801701des", new LanguageData("s801701des", "", "", "微弱风弹的描述", ""));
root.Add("s801801des", new LanguageData("s801801des", "", "", "微弱水弹的描述", ""));
root.Add("s801901des", new LanguageData("s801901des", "", "", "微弱光点的描述", ""));
root.Add("s802001des", new LanguageData("s802001des", "", "", "微弱暗点的描述", ""));
root.Add("s802101des", new LanguageData("s802101des", "", "", "火球的描述", ""));
root.Add("s802201des", new LanguageData("s802201des", "", "", "风球的描述", ""));
root.Add("s802301des", new LanguageData("s802301des", "", "", "水球的描述", ""));
root.Add("s802401des", new LanguageData("s802401des", "", "", "光球的描述", ""));
root.Add("s802501des", new LanguageData("s802501des", "", "", "暗球的描述", ""));
root.Add("s802601des", new LanguageData("s802601des", "", "", "火红药瓶子的描述", ""));
root.Add("s802701des", new LanguageData("s802701des", "", "", "风药瓶子的描述", ""));
root.Add("s802801des", new LanguageData("s802801des", "", "", "水药瓶子的描述", ""));
root.Add("s802901des", new LanguageData("s802901des", "", "", "光药瓶子的描述", ""));
root.Add("s803001des", new LanguageData("s803001des", "", "", "暗药瓶子的描述", ""));
root.Add("s803101des", new LanguageData("s803101des", "", "", "火子弹的描述", ""));
root.Add("s803201des", new LanguageData("s803201des", "", "", "风子弹的描述", ""));
root.Add("s803301des", new LanguageData("s803301des", "", "", "水子弹的描述", ""));
root.Add("s803401des", new LanguageData("s803401des", "", "", "光子弹的描述", ""));
root.Add("s803501des", new LanguageData("s803501des", "", "", "暗子弹的描述", ""));
root.Add("s810101des", new LanguageData("s810101des", "", "", "往前挥砍2刀，每刀造成80%攻击力的水元素伤害", ""));
root.Add("s810201des", new LanguageData("s810201des", "", "", "对前方发出一个刀风，对直线敌人造成160%攻击力的风元素伤害", ""));
root.Add("s810301des", new LanguageData("s810301des", "", "", "Nppba自我回复（特效做）1的描述", ""));
root.Add("s810401des", new LanguageData("s810401des", "", "", "Andy血怒1的描述", ""));
root.Add("s810501des", new LanguageData("s810501des", "", "", "WooWoo疾风二连斩1的描述", ""));
root.Add("s810601des", new LanguageData("s810601des", "", "", "Duden生命恢复1的描述", ""));
root.Add("s810701des", new LanguageData("s810701des", "", "", "对前方发出一个刀风，对直线敌人造成160%攻击力的光元素伤害", ""));
root.Add("s810801des", new LanguageData("s810801des", "", "", "暴击率增加20%，持续10s", ""));
root.Add("s810901des", new LanguageData("s810901des", "", "", "风暴之刃1的描述", ""));
root.Add("s811001des", new LanguageData("s811001des", "", "", "对前方敌人造成160%的风元素伤害", ""));
root.Add("s811101des", new LanguageData("s811101des", "", "", "对前方最近的敌人释放一支火柱，造成3段伤害，每段40%的火元素伤害", ""));
root.Add("s811201des", new LanguageData("s811201des", "", "", "对附近敌人造成160%的水元素伤害", ""));
root.Add("s811301des", new LanguageData("s811301des", "", "", "对身边的敌人用鬼手进行攻击，造成160%攻击力的暗属性伤害", ""));
root.Add("s811401des", new LanguageData("s811401des", "", "", "回旋砍击1的描述", ""));
root.Add("s811501des", new LanguageData("s811501des", "", "", "全体队友回复自身攻击力10%的生命值", ""));
root.Add("s811601des", new LanguageData("s811601des", "", "", "对随机一名友方伤害+10%", ""));
root.Add("s811701des", new LanguageData("s811701des", "", "", "Burton单体防御1的描述", ""));
root.Add("s811801des", new LanguageData("s811801des", "", "", "单体攻速1的描述", ""));
root.Add("s811901des", new LanguageData("s811901des", "", "", "单体暴击1的描述", ""));
root.Add("s812001des", new LanguageData("s812001des", "", "", "Gabriel火柱术1的描述", ""));
root.Add("s812101des", new LanguageData("s812101des", "", "", "Mulu冰锥1的描述", ""));
root.Add("s812201des", new LanguageData("s812201des", "", "", "Dominic光波术1的描述", ""));
root.Add("s812301des", new LanguageData("s812301des", "", "", "弹跳火柴1的描述", ""));
root.Add("s812401des", new LanguageData("s812401des", "", "", "Mulu冰锥术，范围击退1的描述", ""));
root.Add("s812501des", new LanguageData("s812501des", "", "", "连续风球追踪1的描述", ""));
root.Add("s812601des", new LanguageData("s812601des", "", "", "连续光波追踪，击中致盲1的描述", ""));
root.Add("s812701des", new LanguageData("s812701des", "", "", "诅咒飞弹，击中减防1的描述", ""));
root.Add("s812801des", new LanguageData("s812801des", "", "", "Backhaus二连矢1的描述", ""));
root.Add("s812901des", new LanguageData("s812901des", "", "", "Robin穿透箭1的描述", ""));
root.Add("s813001des", new LanguageData("s813001des", "", "", "爆炸射击（火）1的描述", ""));
root.Add("s813101des", new LanguageData("s813101des", "", "", "Barzel三连矢1的描述", ""));
root.Add("s813201des", new LanguageData("s813201des", "", "", "穿透箭1的描述", ""));
root.Add("s813301des", new LanguageData("s813301des", "", "", "爆炸箭（风）1的描述", ""));
root.Add("s813401des", new LanguageData("s813401des", "", "", "爆裂光芒1的描述", ""));
root.Add("s813501des", new LanguageData("s813501des", "", "", "Gizmo重击1的描述", ""));
root.Add("s813601des", new LanguageData("s813601des", "", "", "Sarah冰冻手雷1的描述", ""));
root.Add("s813701des", new LanguageData("s813701des", "", "", "燃烧弹1的描述", ""));
root.Add("s813801des", new LanguageData("s813801des", "", "", "GumBoo快速拔枪（子弹）1的描述", ""));
root.Add("s813901des", new LanguageData("s813901des", "", "", "三连爆炸射击（已有子弹拼）1的描述", ""));
root.Add("s814001des", new LanguageData("s814001des", "", "", "快速装填（特效）1的描述", ""));
root.Add("s814101des", new LanguageData("s814101des", "", "", "重金属单头（特效）1的描述", ""));
root.Add("s815101des", new LanguageData("s815101des", "", "", "Essac防御机制I的描述", ""));
root.Add("s815201des", new LanguageData("s815201des", "", "", "Bobo荆棘护甲ILv.1的描述", ""));
root.Add("s815301des", new LanguageData("s815301des", "", "", "自我防护Lv.1的描述", ""));
root.Add("s815401des", new LanguageData("s815401des", "", "", "Andy嘲讽Lv.1的描述", ""));
root.Add("s815501des", new LanguageData("s815501des", "", "", "团队防护Lv.1的描述", ""));
root.Add("s815601des", new LanguageData("s815601des", "", "", "推开Lv.1的描述", ""));
root.Add("s815701des", new LanguageData("s815701des", "", "", "天引Lv.1的描述", ""));
root.Add("s815801des", new LanguageData("s815801des", "", "", "Erwin狂怒挥击Lv.1的描述", ""));
root.Add("s815901des", new LanguageData("s815901des", "", "", "冲撞Lv.1的描述", ""));
root.Add("s816001des", new LanguageData("s816001des", "", "", "Fabio烈风回旋Lv.1的描述", ""));
root.Add("s816101des", new LanguageData("s816101des", "", "", "血之渴望Lv.1的描述", ""));
root.Add("s816201des", new LanguageData("s816201des", "", "", "Nova水刃回旋Lv.1的描述", ""));
root.Add("s816301des", new LanguageData("s816301des", "", "", "Renato血怒之手Lv.1的描述", ""));
root.Add("s816401des", new LanguageData("s816401des", "", "", "野蛮咆哮Lv.1的描述", ""));
root.Add("s816501des", new LanguageData("s816501des", "", "", "Alex回复术Lv.1的描述", ""));
root.Add("s816601des", new LanguageData("s816601des", "", "", "GuLoo力量恩赐Lv.1的描述", ""));
root.Add("s816701des", new LanguageData("s816701des", "", "", "Paco紧急治疗Lv.1的描述", ""));
root.Add("s816801des", new LanguageData("s816801des", "", "", "圣疗Lv.1的描述", ""));
root.Add("s816901des", new LanguageData("s816901des", "", "", "Fanny回复术IILv.1的描述", ""));
root.Add("s817001des", new LanguageData("s817001des", "", "", "集体加防Lv.1的描述", ""));
root.Add("s817101des", new LanguageData("s817101des", "", "", "天使祝福Lv.1的描述", ""));
root.Add("s817201des", new LanguageData("s817201des", "", "", "Burton单体回复Lv.1的描述", ""));
root.Add("s817301des", new LanguageData("s817301des", "", "", "Umberto毒药攻击Lv.1的描述", ""));
root.Add("s817401des", new LanguageData("s817401des", "", "", "回复药剂Lv.1的描述", ""));
root.Add("s817501des", new LanguageData("s817501des", "", "", "MoMo力量药剂Lv.1的描述", ""));
root.Add("s817601des", new LanguageData("s817601des", "", "", "GinGine防御药剂Lv.1的描述", ""));
root.Add("s817701des", new LanguageData("s817701des", "", "", "清醒药剂Lv.1的描述", ""));
root.Add("s817801des", new LanguageData("s817801des", "", "", "腐蚀药剂Lv.1的描述", ""));
root.Add("s817901des", new LanguageData("s817901des", "", "", "Gabriel火龙卷(bullet重做）Lv.1的描述", ""));
root.Add("s818001des", new LanguageData("s818001des", "", "", "Mulu霜冻新星Lv.1的描述", ""));
root.Add("s818101des", new LanguageData("s818101des", "", "", "Dominic龙卷风Lv.1的描述", ""));
root.Add("s818201des", new LanguageData("s818201des", "", "", "陨石术Lv.1的描述", ""));
root.Add("s818301des", new LanguageData("s818301des", "", "", "暴风雪Lv.1的描述", ""));
root.Add("s818401des", new LanguageData("s818401des", "", "", "狂风术Lv.1的描述", ""));
root.Add("s818501des", new LanguageData("s818501des", "", "", "激光Lv.1的描述", ""));
root.Add("s818601des", new LanguageData("s818601des", "", "", "召唤黑洞Lv.1的描述", ""));
root.Add("s818701des", new LanguageData("s818701des", "", "", "Backhaus蓄力箭Lv.1的描述", ""));
root.Add("s818801des", new LanguageData("s818801des", "", "", "Robin连射击退Lv.1的描述", ""));
root.Add("s818901des", new LanguageData("s818901des", "", "", "铁蒺藜Lv.1的描述", ""));
root.Add("s819001des", new LanguageData("s819001des", "", "", "Barzel爆炸箭Lv.1的描述", ""));
root.Add("s819101des", new LanguageData("s819101des", "", "", "箭雨Lv.1的描述", ""));
root.Add("s819201des", new LanguageData("s819201des", "", "", "狙击姿态Lv.1的描述", ""));
root.Add("s819301des", new LanguageData("s819301des", "", "", "魔法箭Lv.1的描述", ""));
root.Add("s819401des", new LanguageData("s819401des", "", "", "Gizmo暴雨将至Lv.1的描述", ""));
root.Add("s819501des", new LanguageData("s819501des", "", "", "Sarah爆头Lv.1的描述", ""));
root.Add("s819601des", new LanguageData("s819601des", "", "", "烈酒Lv.1的描述", ""));
root.Add("s819701des", new LanguageData("s819701des", "", "", "GumBoo暴雨将至2Lv.1的描述", ""));
root.Add("s819801des", new LanguageData("s819801des", "", "", "爆头2Lv.1的描述", ""));
root.Add("s819901des", new LanguageData("s819901des", "", "", "烈酒2Lv.1的描述", ""));
root.Add("s820001des", new LanguageData("s820001des", "", "", "猛烈装填Lv.1的描述", ""));
root.Add("s900101des", new LanguageData("s900101des", "", "", "boss近战的描述", ""));
root.Add("s900201des", new LanguageData("s900201des", "", "", "吠的描述", ""));
root.Add("s900301des", new LanguageData("s900301des", "", "", "撕咬的描述", ""));
root.Add("s900401des", new LanguageData("s900401des", "", "", "高射炮的描述", ""));
root.Add("s900501des", new LanguageData("s900501des", "", "", "穿刺攻击的描述", ""));
root.Add("s900601des", new LanguageData("s900601des", "", "", "怪物刀砍的描述", ""));
root.Add("s900701des", new LanguageData("s900701des", "", "", "爆弹爆炸的描述", ""));
root.Add("s900801des", new LanguageData("s900801des", "", "", "撞击的描述", ""));
root.Add("s900901des", new LanguageData("s900901des", "", "", "怪物平A单个2s的描述", ""));
root.Add("s901001des", new LanguageData("s901001des", "", "", "怪物平A一堆2s的描述", ""));
root.Add("s901101des", new LanguageData("s901101des", "", "", "怪物平A单个1s的描述", ""));
root.Add("s901201des", new LanguageData("s901201des", "", "", "怪物平A一堆1s的描述", ""));
root.Add("s901301des", new LanguageData("s901301des", "", "", "怪物火箭的描述", ""));
root.Add("s901401des", new LanguageData("s901401des", "", "", "怪物风箭的描述", ""));
root.Add("s901501des", new LanguageData("s901501des", "", "", "怪物水箭的描述", ""));
root.Add("s901601des", new LanguageData("s901601des", "", "", "怪物光箭的描述", ""));
root.Add("s901701des", new LanguageData("s901701des", "", "", "怪物暗箭的描述", ""));
root.Add("s901801des", new LanguageData("s901801des", "", "", "近战怪系数1的描述", ""));
root.Add("s901901des", new LanguageData("s901901des", "", "", "近战怪系数0.9的描述", ""));
root.Add("s902001des", new LanguageData("s902001des", "", "", "近战怪系数0.8的描述", ""));
root.Add("s902101des", new LanguageData("s902101des", "", "", "近战怪系数0.7的描述", ""));
root.Add("s902201des", new LanguageData("s902201des", "", "", "近战怪系数0.6的描述", ""));
root.Add("s902301des", new LanguageData("s902301des", "", "", "近战怪系数0.5的描述", ""));
root.Add("s902401des", new LanguageData("s902401des", "", "", "近战怪系数0.4的描述", ""));
root.Add("s902501des", new LanguageData("s902501des", "", "", "近战怪系数0.3的描述", ""));
root.Add("s902601des", new LanguageData("s902601des", "", "", "近战怪系数0.2的描述", ""));
root.Add("s902701des", new LanguageData("s902701des", "", "", "近战怪系数0.1的描述", ""));
}
public LanguageData GetReadData(string ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as LanguageData;
Debug.LogError("在表格 LanguageData中没有找到ID" + ID);
return null;}
}
public void WriteToFile(string path){}
public int GetCount(){
return root.Count;
}
public List<string> GetDataKeys(){
return new List<string>(root.Keys);
}
public Dictionary<string, string> GetReadDictionary(string key)
{Dictionary<string, string> pairs = new Dictionary<string, string>();
LanguageData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static LanguageData GetData(string ID){
return LanguageDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(string key)
{ return LanguageDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return LanguageDataReader.Instance.GetCount();
}
public static List<string> GetKeys(){
return LanguageDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
LanguageDataReader.Instance.WriteToFile(path);
}

}