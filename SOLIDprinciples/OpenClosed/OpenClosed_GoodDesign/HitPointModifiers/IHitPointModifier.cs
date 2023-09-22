namespace OpenClosed_GoodDesign.HitPointModifiers
{
    public interface IHitPointModifier
    {
        int CalculateModifier(int hitPointValue);
    }
}