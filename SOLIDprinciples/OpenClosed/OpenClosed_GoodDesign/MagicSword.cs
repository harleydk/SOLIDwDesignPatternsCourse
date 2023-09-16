using OpenClosed_BadDesign.PressureSensorImplementations;
using System.Linq;

namespace OpenClosed_BadDesign
{
    public sealed class MagicSword
    {
        private readonly HitPointModifier[] _hitPointModifiers;

        public MagicSword(HitPointModifier[] hitPointModifiers)
        {
            _hitPointModifiers = hitPointModifiers;
        }

        /// <summary>
        /// Gets the average modifier values across all <see cref="HitPointModifier"/>s.
        /// </summary>
        /// <remarks>
        public double GetAverageModifierValue(int hitPointValue)
        {
            double totalModifyValue = _hitPointModifiers.Sum(hitPointModifier => hitPointModifier.CalculateModifierValue(hitPointValue));
            double averageModifyValue = totalModifyValue / _hitPointModifiers.Length;
            return averageModifyValue;
        }
    }
}