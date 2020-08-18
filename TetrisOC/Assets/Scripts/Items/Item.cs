/*
    金币[0]
    钻石[1]
    广告次数[2]
    免广告券[3]
    各类资源[2-1000]
    英雄[1001-2000]
*/

public enum ItemType
{
    Gold,
    Diamond,
    AdShown,
    NoAd,
    Hero,
    Weapon,
    Equip,
    Unknown,
}
public class Item
{
    public int ID;
    public int Num;
    public Item(int id, int num)
    {
        ID = id;
        Num = num;
    }

    public ItemType Type
    {
        get
        {
            if (ID == 0)return ItemType.Gold;
            if (ID == 1)return ItemType.Diamond;
            if (ID == 2)return ItemType.AdShown;
            if (ID == 3)return ItemType.NoAd;
            if (ID > 1000 && ID <= 2000)return ItemType.Hero;
            if (ID > 10000 && ID <= 20000)return ItemType.Weapon;
            if (ID > 20000 && ID <= 30000)return ItemType.Equip;
            return ItemType.Unknown;
        }
    }

    public bool IsNormalType
    {
        get
        {
            return ID <= 1000;
        }
    }
}