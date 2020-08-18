namespace MMGame
{
    public class DiamondText : MMCoinText
    {
        protected override int GetTargetValue()
        {
            return DataModule.Instance.Diamond;
        }

        protected override System.Enum ListenEnum()
        {
            return NoticeEnum.DIAMOND;
        }
    }
}