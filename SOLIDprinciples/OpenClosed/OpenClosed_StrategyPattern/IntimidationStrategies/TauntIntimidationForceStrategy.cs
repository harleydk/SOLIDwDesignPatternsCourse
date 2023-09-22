using System;

namespace OpenClosed_StrategyPattern.IntimidationStrategies
{
    public sealed class TauntIntimidationForceStrategy (TauntLevel tauntLevel): IIntimidationForceStrategy
    {
        public int GetIntimidationForce()
        {
            return tauntLevel switch 
            { 
                TauntLevel.NoviceTaunt => 0, 
                TauntLevel.MasterTaunt => 3, 
                _ => throw new NotImplementedException($"{tauntLevel} not implemented") 
            };
        }
    }

    public enum TauntLevel
    {
        NoviceTaunt,
        MasterTaunt
    }
}