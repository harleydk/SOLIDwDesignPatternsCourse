using System;

namespace InterfaceSegregation_GoodDesign
{
    /// <summary>
    /// The better design is to split the general interface out into separate interfaces, and thus 
    /// allow the SensorCabinetWithoutAlarm to only implement those interfaces it should implement.
    /// </summary>
    /// <see cref="ICabinetOpening"/>
    /// <seealso cref="ICabinetAlarm"/>
    public sealed class Program
    {
        public static void Main()
        {
            // For a 'regular' security-cabinet we attach a an event when the open event occurs,
            SecretCabinet treasureChestFilledWithGold = new SecretCabinet(new CabinetAlarm());
            treasureChestFilledWithGold.CabinetOpenedEvent += CabinetOpenedEvent;
            treasureChestFilledWithGold.FireCabinetOpenedEvent();
            treasureChestFilledWithGold.CabinetOpenedEvent -= CabinetOpenedEvent;

            // and the same for the cabinet without an alarm.
            SecretCabinetWithoutAlarm fakeEmptyTreasureChest = new SecretCabinetWithoutAlarm();
            fakeEmptyTreasureChest.CabinetOpenedEvent += CabinetOpenedEvent;
            fakeEmptyTreasureChest.FireCabinetOpenedEvent();
            fakeEmptyTreasureChest.CabinetOpenedEvent -= CabinetOpenedEvent;
        }

        /// <summary>
        /// For both types of security-cabinet, we react to their <see cref="ICabinetOpening.CabinetOpenedEvent"/> - but
        /// since we've split the ISecurityCabinet up into individual interfaces, we can test for the <see cref="ICabinetAlarm"/> interface -
        /// if we hadn't applied the interface segregation principle, this would not have been possible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="cabinetOpenedEventArgs"></param>
        private static void CabinetOpenedEvent(object sender, CabinetOpenedEventArgs cabinetOpenedEventArgs)
        {
            if (sender is ICabinetAlarm cabinetThatImplementsAlarm)
            {
                DateTime openTime = cabinetOpenedEventArgs.CabinetOpenTime;
                if (openTime.DayOfWeek >= System.DayOfWeek.Sunday && openTime.DayOfWeek <= System.DayOfWeek.Saturday)
                {
                    cabinetThatImplementsAlarm.RaiseCabinetOpenAlarm();
                }
            }
        }
    }
}