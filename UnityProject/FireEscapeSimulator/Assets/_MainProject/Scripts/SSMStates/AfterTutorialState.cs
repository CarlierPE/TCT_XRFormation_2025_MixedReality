using TcT.FireSim.SSM;
using UnityEngine;

namespace TcT.FireSim
{
    public class AfterTutorialState : ScriptBasedGameState
    {
        public AfterTutorialState(MonoBehaviour script) : base(script) { }

        public override eGameStateID ID => eGameStateID.AfterTutorial;

        public override bool CanTransitionTo(eGameStateID nextState)
        {
            //TODO before tutorial or tutorial?
            return nextState == eGameStateID.BeforeSimulation || nextState == eGameStateID.BeforeTutorial;
        }
    }
}