namespace InterfaceSegregation_BadDesign
{
    /// <summary>
    /// The interface segregation principle states that no class should be forced to implement interface-methods it has not need for. 
    /// Below, a <see cref="SecretCabinetWithoutAlarm"/>() shouldn't have to implement <see cref="ISecretCabinet"/>-methods regarding alarms.
    /// 
    /// The principle mainly addresses the concern of bloat, in as much as it's a clear sign something that would usually be split into 
    /// its own has not been.
    /// </summary>
    /// <remarks>
    /// Where do 'heavy' interfaces usually derive from? Usually technical debt: The World-view of once was is no longer valid.
    /// Such as with the example below. We can imagine how the original product, a security cabinet with an attached alarm, was a bit hit - 
    /// but some clients requested a cabinet _without_ an alarm. Yet the original interface was allowed to remain.
    /// </remarks>
    public sealed class Program
    {
        public static void Main()
        {
            // For a 'regular' treasureChestFilledWithGold we attach a an event that raises an alarm when the open event occurs,
            // because we have that method available to us via the <see cref="ISecretCabinet"/>-interface.
            SecretCabinet treasureChestFilledWithGold = new (new CabinetAlarm());
            treasureChestFilledWithGold.CabinetOpenedEvent += CabinetOpenedEvent;
            treasureChestFilledWithGold.FireCabinetOpenedEvent();
            treasureChestFilledWithGold.CabinetOpenedEvent -= CabinetOpenedEvent;

            // But for a fakeEmptyTreasureChest without alarm, we'll get an exception when we try to raise an alarm,
            // since for this <see cref="ISecretCabinet"/>-implementation we haven't implemented the 'RaiseCabinetOpenAlarm' method. 
            SecretCabinetWithoutAlarm fakeEmptyTreasureChest = new();
            fakeEmptyTreasureChest.CabinetOpenedEvent += CabinetOpenedEvent;
            fakeEmptyTreasureChest.FireCabinetOpenedEvent();
            fakeEmptyTreasureChest.CabinetOpenedEvent -= CabinetOpenedEvent;
        }

        private static void CabinetOpenedEvent(object sender, CabinetOpenedEventArgs cabinetOpenedEventArgs)
        {
            System.DateTime openTime = cabinetOpenedEventArgs.CabinetOpenTime;
            if (openTime.DayOfWeek >= System.DayOfWeek.Sunday && openTime.DayOfWeek <= System.DayOfWeek.Saturday)
            {
                ((ISecretCabinet)sender).RaiseCabinetOpenAlarm();
            }
        }
    }
}