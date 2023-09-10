using InterfaceSegregation;
using System;
using System.Diagnostics;

namespace InterfaceSegregation_GoodDesign
{
    /// <summary>
    /// The better design is to split the general interface out into separate interfaces, and thus 
    /// allow the SensorCabinetWithoutAlarm to only implement those interfaces it should implement.
    /// </summary>
    /// <see cref="ICabinetOpening"/>
    /// <seealso cref="ICabinetAlarming"/>
    public sealed class Program
    {
        public static void Main()
        {
            // For a 'regular' security-cabinet we attach a an event when the open event occurs,
            SecurityCabinet securityCabinet = new SecurityCabinet(new CabinetAlarm());
            securityCabinet.CabinetOpenedEvent += CabinetOpenedEvent;
            securityCabinet.FireCabinetOpenedEvent();
            securityCabinet.CabinetOpenedEvent -= CabinetOpenedEvent;

            // and the same for the cabinet without an alarm.
            SensorCabinetWithoutAlarm securityCabinetWithoutAlarm = new SensorCabinetWithoutAlarm();
            securityCabinetWithoutAlarm.CabinetOpenedEvent += CabinetOpenedEvent;
            securityCabinetWithoutAlarm.FireCabinetOpenedEvent();
            securityCabinetWithoutAlarm.CabinetOpenedEvent -= CabinetOpenedEvent;
        }

        /// <summary>
        /// For both types of security-cabinet, we react to their <see cref="ICabinetOpening.CabinetOpenedEvent"/> - but
        /// since we've split the ISecurityCabinet up into individual interfaces, we can test for the <see cref="ICabinetAlarming"/> interface -
        /// if we hadn't applied the interface segregation principle, this would not have been possible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="cabinetOpenedEventArgs"></param>
        private static void CabinetOpenedEvent(object sender, CabinetOpenedEventArgs cabinetOpenedEventArgs)
        {
            if (sender is ICabinetAlarming cabinetThatImplementsAlarm)
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