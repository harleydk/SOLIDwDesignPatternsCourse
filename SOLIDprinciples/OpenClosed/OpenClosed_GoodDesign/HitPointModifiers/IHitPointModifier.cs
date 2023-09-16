namespace OpenClosed_GoodDesign.HitPointModifiers
{
    public interface IHitPointModifier
    {
        double CalculateModifierValue(int hitPointValue);
    }
}