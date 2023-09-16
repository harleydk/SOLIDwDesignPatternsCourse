using System;

namespace OpenClosed_StrategyPattern.IntimidationStrategies
{
    public sealed class TauntIntimidationForceStrategy : IIntimidationForceStrategy
    {
        private readonly TauntLevel _tauntLevel;

        public TauntIntimidationForceStrategy(TauntLevel tauntLevel)
        {
            _tauntLevel = tauntLevel;
        }

        public int GetIntimidationForce()
        {
            return _tauntLevel switch 
            { 
                TauntLevel.NoviceTaunt => 0, 
                TauntLevel.MasterTaunt => 3, 
                _ => throw new NotImplementedException($"{_tauntLevel} not implemented") 
            };
        }
    }

    public enum TauntLevel
    {
        NoviceTaunt,
        MasterTaunt
    }
}