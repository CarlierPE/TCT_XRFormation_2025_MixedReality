using TcT.FireSim.SSM;
using UnityEngine;

namespace TcT.FireSim
{
    public class DebriefingState : ScriptBasedGameState
    {
        public DebriefingState(MonoBehaviour script) : base(script) { }

        public override eGameStateID ID => eGameStateID.Debriefing;

        public override bool CanTransitionTo(eGameStateID nextState)
        {
            return nextState == eGameStateID.Started;
        }
    }
}