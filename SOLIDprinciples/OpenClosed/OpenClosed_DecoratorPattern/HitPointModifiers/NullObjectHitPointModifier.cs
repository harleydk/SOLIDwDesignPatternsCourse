using System.Diagnostics;

namespace OpenClosed_GoodDesign.HitPointModifiers
{
    /// <summary>
    /// A <see cref="NullObjectHitPointModifier"/> is an implementation of an <seealso cref="IHitPointModifier"/> that returns 0 (zero) for
    /// its <seealso cref="CalculateModifierValue(int)"/> method.
    /// </summary>
    public sealed class NullObjectHitPointModifier : IHitPointModifier
    {
        public NullObjectHitPointModifier()
        {
        }

        public int CalculateModifierValue(int hitPointValue)
        {
            Debug.WriteLine($"{typeof(NullObjectHitPointModifier).Name} returns 0");
            return 0;
        }

        public static NullObjectHitPointModifier Create()
        {
            return new NullObjectHitPointModifier();
        }
    }
}
