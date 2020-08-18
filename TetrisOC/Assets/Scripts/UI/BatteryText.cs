namespace MMGame
{
    public class BatteryText : MMCoinText
    {
        protected override int GetTargetValue()
        {
            return DataModule.Instance.Battery;
        }

        protected override System.Enum ListenEnum()
        {
            return NoticeEnum.BATTERY;
        }
    }
}