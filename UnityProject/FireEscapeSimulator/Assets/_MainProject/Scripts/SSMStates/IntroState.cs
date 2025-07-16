
using UnityEngine;

namespace TcT.FireSim.SSM
{
    public class IntroState : ScriptBasedGameState
    {
        public IntroState(MonoBehaviour script) : base(script) { }

        public override eGameStateID ID => eGameStateID.Intro;

        public override bool CanTransitionTo(eGameStateID nextState)
        {
            return nextState == eGameStateID.Started;
        }
    }
}