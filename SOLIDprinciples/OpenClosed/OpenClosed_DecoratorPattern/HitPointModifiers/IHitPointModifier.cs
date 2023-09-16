namespace OpenClosed_GoodDesign.HitPointModifiers
{
    public interface IHitPointModifier
    {
        int CalculateModifierValue(int hitPointValue);
    }
}
