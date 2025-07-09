using TcT.FireSim.SSM;
using UnityEngine;

namespace TcT.FireSim
{
    public class SimulationState : ScriptBasedGameState
    {
        public SimulationState(MonoBehaviour script) : base(script) { }

        public override eGameStateID ID => eGameStateID.Simulation;

        public override bool CanTransitionTo(eGameStateID nextState)
        {
            return nextState == eGameStateID.AfterSimulation;
        }
    }
}