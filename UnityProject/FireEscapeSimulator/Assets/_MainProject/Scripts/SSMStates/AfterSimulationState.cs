using TcT.FireSim.SSM;
using UnityEngine;

namespace TcT.FireSim
{
    public class AfterSimulationState : ScriptBasedGameState
    {
        public AfterSimulationState(MonoBehaviour script) : base(script) { }

        public override eGameStateID ID => eGameStateID.AfterSimulation;

        public override bool CanTransitionTo(eGameStateID nextState)
        {
            return nextState == eGameStateID.Debriefing;
        }
    }
}