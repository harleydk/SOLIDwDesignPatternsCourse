namespace OpenClosed_StrategyPattern.HitPointModifiers
{
    public interface IHitPointModifier
    {
        double CalculateModifierValue(int hitPointValue);
    }
}