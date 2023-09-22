using System;

namespace OpenClosed_GoodDesign.HitPointModifiers
{
    /// <summary>
    /// The <see cref="HitPointModifierDecorator"/> class 'wraps' the <see cref="HitPointModifierBase"/> implementation and maintains a 
    /// reference - <see cref="_hitPointModifier"/> - to an <seealso cref="IHitPointModifier"/>. When classes such as <seealso cref="IntimidationHitPointModifier"/>
    /// implements this decorator-class, they send an interface implementations along - which allows us to chain, or decorate, similar implementations and 
    /// inject new functionality into existing <see cref="HitPointModifierDecorator"/> sub-classes.
    /// </summary>
    public abstract class HitPointModifierDecorator(int modifierValue, int abilityBonus, IHitPointModifier hitPointModifier) : HitPointModifierBase(modifierValue, abilityBonus)
    {
        /// <summary>
        /// Implements the <see cref="HitPointModifierBase.CalculateModifier(int)"/> method with an option to override.
        /// </summary>
        public override int CalculateModifier(int hitPointValue)
        {
            int decoratorHitPointModifier = hitPointModifier.CalculateModifier(hitPointValue);
            int baseHitPointModifier = base.CalculateModifier(hitPointValue);

            return baseHitPointModifier + decoratorHitPointModifier;
        }
    }
}
