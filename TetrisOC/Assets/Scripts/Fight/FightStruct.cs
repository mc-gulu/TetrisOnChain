using System.Collections.Generic;
using System.Linq;

namespace MMGame
{
    public class CreatureBuild
    {
        public int posID;
        public int lv;
        public int star;
        public int creatureid;
        public float delay;
    }

    public class FightStruct
    {
        public List<CreatureBuild> herobuildlist;
        public List<List<CreatureBuild>> enimybuildlist;

        public List<int> GetSingleEnimy() 
        {
            var tmplist = new List<int>();
            foreach (var list in enimybuildlist)
            {
                foreach (var build in list)
                {
                    if (!tmplist.Contains(build.creatureid))
                    {
                        tmplist.Add(build.creatureid);
                    }
                }
            }
            return tmplist;
        }
    }
}


