﻿using System;
using System.Diagnostics;

namespace InterfaceSegregation_BadDesign
{
    /// <summary>
    /// A 'regular' secret cabinet. Includes an alarm, that fires when the <see cref="CabinetOpenedEvent"/> 
    /// </summary>
    public class SecretCabinet : ISecretCabinet
    {
        private readonly CabinetAlarm _cabinetAlarm;

        public event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;

        public SecretCabinet(CabinetAlarm cabinetAlarm)
        {
            _cabinetAlarm = cabinetAlarm;
        }

        public CabinetOperationResult FireCabinetOpenedEvent()
        {
            CabinetOpenedEvent?.Invoke(this, new CabinetOpenedEventArgs { CabinetOpenTime = DateTime.UtcNow });
            return CabinetOperationResult.PresumedSucceeded;
        }

        public CabinetOperationResult RaiseCabinetOpenAlarm()
        {
            _cabinetAlarm.RaiseCabinetAlarm();
            return CabinetOperationResult.PresumedSucceeded;
        }
    }
}