using OpenClosed_StrategyPattern.HitPointModifiers;
using System.Linq;

namespace OpenClosed_StrategyPattern
{
    public sealed class MagicSword
    {
        private readonly HitPointModifierBase[] _hitPointModifiers;

        public MagicSword(HitPointModifierBase[] hitPointModifiers)
        {
            _hitPointModifiers = hitPointModifiers;
        }

        /// <summary>
        /// Gets the modifier values across all <see cref="HitPointModifierBase"/>s.
        /// </summary>
        /// <remarks>
        public double GetTotalModifierValue(int hitPointValue)
        {
            double totalModifyValue = _hitPointModifiers.Sum(hitPointModifier => hitPointModifier.CalculateModifierValue(hitPointValue));
            return totalModifyValue;
        }
    }
}