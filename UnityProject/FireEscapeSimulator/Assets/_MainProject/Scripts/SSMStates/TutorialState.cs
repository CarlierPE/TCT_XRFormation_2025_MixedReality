using TcT.FireSim.SSM;
using UnityEngine;

namespace TcT.FireSim
{
    public class TutorialState : ScriptBasedGameState
    {
        public override eGameStateID ID => eGameStateID.Tutorial;
        private MonoBehaviour _tutorialScript;

        public TutorialState(MonoBehaviour script) : base(script) { }

        public override bool CanTransitionTo(eGameStateID nextState)
        {
            return nextState == eGameStateID.AfterTutorial;
        }
    }
}