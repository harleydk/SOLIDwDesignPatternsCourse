using System;

namespace OpenClosed_GoodDesign.HitPointModifiers
{
    /// <summary>
    /// The <see cref="HitPointModifierDecorator"/> class 'wraps' the <see cref="HitPointModifierBase"/> implementation and maintains a 
    /// reference - <see cref="_hitPointModifier"/> - to an <seealso cref="IHitPointModifier"/>. When classes such as <seealso cref="IntimidationHitPointModifier"/>
    /// implements this decorator-class, they send an interface implementations along - which allows us to chain, or decorate, similar implementations and 
    /// inject new functionality into existing <see cref="HitPointModifierDecorator"/> sub-classes.
    /// </summary>
    public abstract class HitPointModifierDecorator : HitPointModifierBase
    {
        private readonly IHitPointModifier _hitPointModifier;

        protected HitPointModifierDecorator(int modifierValue, int abilityBonus, IHitPointModifier hitPointModifier) : 
            base(modifierValue, abilityBonus)
        {
            _hitPointModifier = hitPointModifier;
        }

        /// <summary>
        /// Implements the <see cref="HitPointModifierBase.CalculateModifierValue(int)"/> method with an option to override.
        /// </summary>
        public override int CalculateModifierValue(int hitPointValue)
        {
            int decoratorHitPointModifier = _hitPointModifier.CalculateModifierValue(hitPointValue);
            int baseHitPointModifier = base.CalculateModifierValue(hitPointValue);

            return baseHitPointModifier + decoratorHitPointModifier;
        }
    }
}
