﻿using OpenClosed_StrategyPattern.HitPointModifiers;
using System.Linq;

namespace OpenClosed_StrategyPattern
{
    public sealed class MagicSword(HitPointModifierBase[] hitPointModifiers)
    {
        /// <summary>
        /// Gets the modifier values across all <see cref="HitPointModifierBase"/>s.
        /// </summary>
        /// <remarks>
        public int GetTotalModifierValue(int hitPointValue)
        {
            int totalModifyValue = hitPointModifiers.Sum(hitPointModifier => hitPointModifier.CalculateModifier(hitPointValue));
            return totalModifyValue;
        }
    }
}