using OpenClosed_GoodDesign.HitPointModifiers;
using System.Linq;

namespace OpenClosed_GoodDesign
{
    public sealed class MagicSword
    {
        private readonly HitPointModifierDecorator _hitPointModifierDecorator;

        public MagicSword(HitPointModifierDecorator hitPointModifierDecorator)
        {
            _hitPointModifierDecorator = hitPointModifierDecorator;
        }

        /// <summary>
        /// Gets the modifier values by un-winding all <see cref="HitPointModifierDecorator"/>s.
        /// </summary>
        /// <remarks>
        public double GetTotalModifierValue(int hitPointValue)
        {
            double totalModifyValue = _hitPointModifierDecorator.CalculateModifierValue(hitPointValue);
            return totalModifyValue;
        }
    }
}