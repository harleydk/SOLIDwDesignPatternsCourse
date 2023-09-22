namespace OpenClosed_StrategyPattern.HitPointModifiers
{
    public interface IHitPointModifier
    {
        int CalculateModifier(int hitPointValue);
    }
}