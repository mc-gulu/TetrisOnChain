using System.Collections;
using System.Collections.Generic;
using MMFramework;
using UnityEngine;
namespace MMGame
{
    public struct EnimyStruct
    {
        public int creatureID; //外观,武器,技能
        // public int physiqueIndex; //体质
        public int lv; //等级
        public int star;//星级
        public int num; //个数
        public int birthIndex; //出生点
        // public string btname; //行为树
        // public string headname;
        public EnimyStruct(EnimyStruct enimyData)
        {
            creatureID = enimyData.creatureID;
            lv = enimyData.lv;
            star = enimyData.star;
            num = enimyData.num;
            birthIndex = enimyData.birthIndex;
        }
        public EnimyStruct(ZZZ_EnimyData enimyData)
        {
            creatureID = enimyData.CreatureID;
            lv = enimyData.AddLv;
            star = enimyData.AddStar;
            num = enimyData.Num;
            birthIndex = enimyData.birthIndex;
        }
        public EnimyStruct(int creatureID, int lv, int star, int num, int birthIndex)
        {
            this.creatureID = creatureID;
            this.lv = lv;
            this.star = star;
            this.num = num;
            this.birthIndex = birthIndex;
        }
    }
    public class EnimyModule : MonoBehaviour, BaseModule
    {
        public static EnimyModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<EnimyModule>();
            }
        }

        Dictionary<int, List<List<EnimyStruct>>> game_enimies;
        // HashSet<string> btlist;
        public void Init()
        {
            game_enimies = new Dictionary<int, List<List<EnimyStruct>>>();
            // btlist = new HashSet<string>();
            Dictionary<int, Dictionary<int, List<EnimyStruct>>> enimies = new Dictionary<int, Dictionary<int, List<EnimyStruct>>>();
            List<string> keylist = ZZZ_EnimyData.GetKeys();
            for (int i = 0; i < keylist.Count; i++)
            {
                string key = keylist[i];
                ZZZ_EnimyData enimyData = ZZZ_EnimyData.GetData(key);

                if (!enimies.ContainsKey(enimyData.roomTag))
                    enimies.Add(enimyData.roomTag, new Dictionary<int, List<EnimyStruct>>());
                if (!enimies[enimyData.roomTag].ContainsKey(enimyData.indexTag))
                    enimies[enimyData.roomTag].Add(enimyData.indexTag, new List<EnimyStruct>());

                enimies[enimyData.roomTag][enimyData.indexTag].Add(new EnimyStruct(enimyData));
            }

            foreach (var item in enimies)
            {
                game_enimies.Add(item.Key, new List<List<EnimyStruct>>(item.Value.Values));
            }
        }

        public List<List<EnimyStruct>> GetEnimies(int roomTag)
        {
            if (game_enimies.ContainsKey(roomTag))
            {
                List<List<EnimyStruct>> list = new List<List<EnimyStruct>>();
                for (int i = 0; i < game_enimies[roomTag].Count; i++)
                {
                    list.Add(new List<EnimyStruct>());
                    for (int j = 0; j < game_enimies[roomTag][i].Count; j++)
                    {
                        list[i].Add(game_enimies[roomTag][i][j]);
                    }
                }
                return list;
            }
            else
            {
                Debug.LogError("Error GetEnimies roomTag:" + roomTag);
                return null;
            }
        }

        // public HashSet<string> GetBtNames()
        // {
        //     return btlist;
        // }
    }
}