namespace OpenClosed_StrategyPattern.HitPointModifiers
{
    public interface IHitPointModifier
    {
        int CalculateModifierValue(int hitPointValue);
    }
}