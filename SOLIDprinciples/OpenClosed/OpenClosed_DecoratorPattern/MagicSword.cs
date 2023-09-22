using OpenClosed_GoodDesign.HitPointModifiers;
using System.Linq;

namespace OpenClosed_GoodDesign
{
    public sealed class MagicSword(HitPointModifierDecorator hitPointModifierDecorator)
    {
        /// <summary>
        /// Gets the modifier values by un-winding all <see cref="HitPointModifierDecorator"/>s.
        /// </summary>
        /// <remarks>
        public int GetTotalModifierValue(int hitPointValue)
        {
            int totalModifyValue = hitPointModifierDecorator.CalculateModifier(hitPointValue);
            return totalModifyValue;
        }
    }
}