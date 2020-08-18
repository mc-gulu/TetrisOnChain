public enum NoticeEnum
{
    NONE,
    HANDLE_CONTROL,
    FLAG,
    ACTIVE_ROOM,
    CLEAR_ROOM,
    FINISH_ROOM,
    ROGUELIKE_OPENBOX,
    SETTING_GIVEUP,
    ROGUELIKE_PASSSUCCESS,
    GM_ROGUELIKE_GETALLDROPS,
    GM_ROGUELIKE_NEXTFLOOR,
    GM_GOTO_FINAL_LEVEL,
    GM_ALL_ROOM_PASS,
    ENIMY_DEAD,
    HERO_DEAD,
    SAFE_OR_NOT,
    FRAME_ADD,
    FRAME_DEL,
    FRAME_DEL_ALL,
    FRAME_TAG_ACTION,
    GOLD,
    GOLD_PART,
    DIAMOND,
    Exp,
    BATTERY,
    HEROLV_CHANGED,
    HERO_RESET,
    HERO_STARUP,
    BATTERY_IN,
    BATTERY_OUT,
    GOLD_CACHE_ADD,
    TEAM_REMOVE,
    EMAIL_UPDATE,
    UPDATE_REDPOINT,
    UPDATE_LOTTERY,
    TimeLeftCountEat,
    CHECKIN_UPDATE,
    UPDATE_DAYS,
    WARNING_FINISH,

    LogicUpdate,
    MASK_LOGIC_FINISH,//Mask完成，通知Module
    MASK_CLEAR,//Module清理MaskManager
    MASK_UPDATE,//更新步骤
    MASK_SHOW,//UI告诉MaskManager,显示对应的Mask

    TOUCH_MASK_BUSY,
    HURT,
    GROUPFINISH,
    GUILD_GET_GOLD,//timeline中获得金币

    MAINLV_UPDATE,

    CLEAR_GROUND_COIN,

    AUTO_HARVESTGROUND,//自动收取发起
    HARVESTGROUND_UI,//收获时候表现UI的通知

    FLY_RESOURCES,//飞资源

    TimelineFinish,//胜利，播完场景动画
    FailedReturn,//失败返回
    TutorialDrop,//新手引导掉落一个金币

    TASK_REWARD_EXTRA,//额外奖励
}