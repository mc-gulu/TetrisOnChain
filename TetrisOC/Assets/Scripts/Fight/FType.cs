namespace MMGame
{
    public enum FType
    {
        ATK = 1, //攻击力数值
        DEF = 21, //防御力数值
        MAXHP = 20, //生命值

        BIGP_UP_P = 4, //暴击率增加比
        BIGP_DOWN_P = 5, //暴击率减少比

        // BIGD_UP_P = 6,//暴击攻击力增加比
        // BIGD_DOWN_P = 7,//暴击攻击力减少比

        ATK_UP_P = 2, //攻击增加比
        ATK_DOWN_P = 3, //攻击减少比
        DEF_UP_P = 22, //防御增加比
        DEF_DOWN_P = 23, //防御减少比,受伤加深

        ATK_FIRE_UP_P = 8,//火系攻击增加比
        ATK_FIRE_DOWN_P = 9,//火系攻击减少比
        ATK_WIND_UP_P = 10,//风系攻击增加比
        ATK_WIND_DOWN_P = 11,//风系攻击减少比
        ATK_WATER_UP_P = 12,//水系攻击增加比
        ATK_WATER_DOWN_P = 13,//水系攻击减少比
        ATK_LIGHT_UP_P = 14,//光系攻击增加比
        ATK_LIGHT_DOWN_P = 15,//光系攻击减少比
        ATK_DARK_UP_P = 16,//暗系攻击增加比
        ATK_DARK_DOWN_P = 17,//暗系攻击减少比
        ATK_PHY_UP_P = 18,//物理系攻击增加比
        ATK_PHY_DOWN_P = 19,//物理系攻击减少比

        DEF_FIRE_UP_P = 24,//火系抗性增加比
        DEF_FIRE_DOWN_P = 25,//火系抗性减少比
        DEF_WIND_UP_P = 26,//风系抗性增加比
        DEF_WIND_DOWN_P = 27,//风系抗性减少比
        DEF_WATER_UP_P = 28,//冰系抗性增加比
        DEF_WATER_DOWN_P = 29,//冰系抗性减少比
        DEF_LIGHT_UP_P = 30,//光系抗性增加比
        DEF_LIGHT_DOWN_P = 31,//光系抗性减少比
        DEF_DARK_UP_P = 32,//暗系抗性增加比
        DEF_DARK_DOWN_P = 33,//暗系抗性减少比
        DEF_PHY_UP_P = 34,//物理系抗性增加比
        DEF_PHY_DOWN_P = 35,//物理系抗性减少比

        REALDAM_P = 36,//真伤占比
        ATK_SPEED_UP_P = 37, //攻速增加加成
        ATK_SPEED_DOWN_P = 38, //攻速减少加成
        // TOU = 39, //韧性
        // TOU_UP_P = 40,//韧性增加百分比（new）
        ATK_ENIMY_ATTACH_BUFF = 41, //攻击到敌人时，会有 {0:P1}的概率使敌人附带{1}Buff{2}{3}
        ATK_PARTERNER_ATTACH_BUFF = 42, //攻击到友军时，会有 {0:P1}的概率使敌友军带{1}Buff{2}{3}
        ATK_ENIMY_SELF_ATTACH_BUFF = 43,//对敌人施放技能时，会有 {0:P1}的概率使自己附带{1}Buff{2}{3}
        ATK_SELF_SELF_ATTACH_BUFF = 44,//对自己施放技能时，会有 {0:P1}的概率使自己附带{1}Buff{2}{3}
        ATK_PARTENER_SELF_ATTACH_BUFF = 45,//对友军施放技能时，会有 {0:P1}的概率使自己附带{1}Buff{2}{3}

        MAX = 50,//最后一个Type
        //VAMPIRE_P = 8, //吸血加成
        //CONVERT_P = 9, //伤害转变为治愈
        //RECOVER_HP_P = 10, //回血增益
        //RECOVER_HP = 11, //额外回血
        //MSPEED = 12, //移动速度
        //MSPEED_STRONG_P = 13, //增加移速加成
        //MSPEED_WEAK_P = 14, //减少移速加成
        //FSPEED = 15, //攻击速度
        //HP_P = 18, //生命值百分比
        //BUFF = 19, //BUFF
        //Range = 22, //攻击范围
        //CD_LONG = 23, //技能CD+
        //CD_SHORT = 24, //技能CD-

        //    HP2ATK = 26, //生命值每减少1%攻击力上升{0:P1}
        //    SUIT = 27, //套装
        //    ATTACH_NORMAL = 28,
        //    ATTACH_SKILL = 29,
        //    ATTACH_SELF = 30,
        //    HP_FULL_ADD_ATK_STRONG_P = 34, //满血加攻击加成
        //    HP_FULL_ADD_ATK_WEEK_P = 35, //满血加攻击加成
        //    HP_HELF_ADD_ATK_STRONG_P = 36, //半血加攻击加成
        //    HP_HELF_ADD_ATK_WEEK_P = 37, //半血加攻击加成
        //    INVINCIBLE = 38, //无敌
        //    FORBID_MOVE = 39, //禁止移动
        //    FORBID_ATK = 40, //禁止攻击
        //    LEFT_30BLOOD_BIGATK = 43, //血量剩余30%加暴击率
        //    ATTACKED_SKILL = 44, //受到敌人攻击后释放一个技能
        //    ENIMYDEAD_SKILL = 45, //击杀敌人后释放一个技能
        //    PRESSSKILL_SKILL = 46, //按钮释放一个技能后释放一个技能

    }
}