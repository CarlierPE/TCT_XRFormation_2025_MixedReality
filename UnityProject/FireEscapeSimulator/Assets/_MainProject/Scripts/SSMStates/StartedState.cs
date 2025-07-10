using TcT.FireSim.SSM;
using UnityEngine;

namespace TcT.FireSim
{
    public class StartedState : ScriptBasedGameState
    {
        public StartedState(MonoBehaviour script) : base(script) { }

        public override eGameStateID ID => eGameStateID.Started;

        public override bool CanTransitionTo(eGameStateID nextState)
        {
            return nextState == eGameStateID.Uncalibrated;
        }
    }
}