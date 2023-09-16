﻿using System.Diagnostics;

namespace OpenClosed_GoodDesign.HitPointModifiers
{

    public abstract class HitPointModifierBase : IHitPointModifier
    {
        protected readonly int _modifierValue;
        protected readonly int _abilityBonus;

        public HitPointModifierBase(int modifierValue, int abilityBonus)
        {
            _modifierValue = modifierValue;
            _abilityBonus = abilityBonus;
        }

        public virtual int CalculateModifierValue(int hitPointValue)
        {
            int modifierValue = _modifierValue + _abilityBonus;
            Debug.WriteLine($"{this.GetType().Name} returns {modifierValue}");
            return modifierValue;
        }

    }
}
