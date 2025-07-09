using TcT.FireSim.SSM;
using UnityEngine;

namespace TcT.FireSim
{
    public class CalibratedState : ScriptBasedGameState
    {
        public override eGameStateID ID => eGameStateID.Calibrated;
        public override bool CanTransitionTo(eGameStateID nextState)
        {
            return nextState == eGameStateID.Uncalibrated || nextState == eGameStateID.BeforeTutorial;
        }

        public CalibratedState(MonoBehaviour script) : base(script) { }
    }
}