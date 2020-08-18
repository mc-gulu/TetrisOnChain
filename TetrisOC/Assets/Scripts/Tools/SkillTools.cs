using System.Collections.Generic;
using MMFramework;
namespace MMGame
{
    public static class SkillTools
    {
        public static List<FireNode> GetFireNode(int skillID)
        {
            SkillData skill = SkillData.GetData(skillID);
            List<FireNode> retlist = new List<FireNode>();
            FireNode[] nodes = new FireNode[3] { null, null, null };
            for (int i = 0; i < skill.FireArray.Length; i++)
            {
                int fireID = skill.FireArray[i];
                if (fireID > 0)
                {
                    nodes[i] = new FireNode();
                    nodes[i].fireID = fireID;
                    nodes[i].next = new List<FireNode>();
                    int pos = skill.PosArray[i] - 1;
                    if (pos < 0)
                        retlist.Add(nodes[i]);
                    else
                        nodes[pos].next.Add(nodes[i]);
                }
                else
                    break;
            }
            return retlist;
        }
        /*名字完全相等*/
        public static float GetAnimatonTime(UnityEngine.Animator _animator, string animationname)
        {
            if (_animator == null)
            {
                return 0;
            }
            if (_animator.runtimeAnimatorController == null)
            {
                return 0;
            }
            string clipsname = animationname;
            for (int i = 0; i < _animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                UnityEngine.AnimationClip clip = _animator.runtimeAnimatorController.animationClips[i];
                if (clip.name.Equals(clipsname))
                    return clip.length;
            }
            return 0;
        }
        /*名字只匹配末尾字符相等*/
        public static float MatchAnimatonTime(UnityEngine.Animator _animator, string animationname)
        {
            if (_animator == null)
            {
                return 0;
            }
            if (_animator.runtimeAnimatorController == null)
            {
                return 0;
            }
            string clipsname = animationname;
            for (int i = 0; i < _animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                UnityEngine.AnimationClip clip = _animator.runtimeAnimatorController.animationClips[i];
                if (clip.name.EndsWith(clipsname))
                    return clip.length;
            }
            return 0;
        }

        public static string GetSkillDesc(int skillgroupid, int lv) 
        {
            SkillData nextlvdata = null, curlvdata = null;
            int nextlvneed = 0;

            var sgdata = SkillGroupData.GetData(skillgroupid);
            for (int i = 0; i < sgdata.LvArray.Length; i++)
            {
                if (lv < sgdata.LvArray[i])
                {
                    nextlvdata = SkillData.GetData(sgdata.IDArray[i]);
                    nextlvneed = sgdata.LvArray[i];
                    curlvdata = SkillData.GetData(sgdata.IDArray[i - 1]);
                    break;
                }
                else if (sgdata.LvArray[i] == 0) 
                {
                    nextlvdata = null;
                    curlvdata = SkillData.GetData(sgdata.IDArray[i - 1]);
                    break;
                }
                else if (i == sgdata.LvArray.Length - 1)
                {
                    nextlvdata = null;
                    curlvdata = SkillData.GetData(sgdata.IDArray[i]);
                    break;
                }
            }

            var str = curlvdata.Description;
            if (nextlvdata != null)
            {
                str += "\n";
                str += string.Format("技能升级条件：角色达到{0}级\n", nextlvneed);
                str += "下一等级效果：\n";
                str += nextlvdata.Description;
            }
            return str;
        }
    }
}