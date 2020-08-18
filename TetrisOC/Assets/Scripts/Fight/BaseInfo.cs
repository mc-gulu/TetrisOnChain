namespace MMGame
{
    public class BaseInfo
    {
        public int id;
        public int creatureID; //
        public int physiqueIDIndex; //体质
        public int Lv; //等级
        public int birthIndex;//出生点
        public int weaponID;
        public int[] equipslots;
        public CreatureType ctype;

        public int star { get; internal set; }
        public Xint spskillid { get; internal set; }
    }
}