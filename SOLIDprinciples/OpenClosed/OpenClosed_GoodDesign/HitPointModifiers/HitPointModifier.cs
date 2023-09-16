namespace OpenClosed_BadDesign.PressureSensorImplementations
{
    public abstract class HitPointModifier
    {
        protected readonly int _modifierValue;
        protected readonly int _abilityBonus;

        public HitPointModifier(int modifierValue, int abilityBonus)
        {
            _modifierValue = modifierValue;
            _abilityBonus = abilityBonus;
        }

        public virtual double CalculateModifierValue(int hitPointValue)
        {
            double modifierValue = (double)_modifierValue / _abilityBonus;
            return modifierValue * hitPointValue;
        }

    }
}
