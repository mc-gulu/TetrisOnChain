using MMFramework;
namespace MMGame
{
    public static class AttribTools
    {
        public static float GetAttrValues(Xint[] attrlist, int genus)
        {
            int[] iattrlist = Xint.ConvertArray(attrlist);
            return GetAttrValues(iattrlist, genus);
        }

        public static float GetAttrValues(int[] attrlist, int genus)
        {
            float retvalue = 0f;
            if (attrlist != null)
            {
                for (int j = 0; j < attrlist.Length; j++)
                {
                    int attrID = attrlist[j];
                    if (attrID > 0)
                    {
                        AttributeData data = AttributeData.GetData(attrID);
                        int igenus = data.FTypeNum;
                        if (igenus.Equals(genus))
                        {
                            retvalue += data.Value;
                        }
                    }
                }
            }
            return retvalue;
        }
    }
}