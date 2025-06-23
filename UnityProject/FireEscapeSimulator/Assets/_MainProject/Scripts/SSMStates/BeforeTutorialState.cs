using FireSim.SSM;
using UnityEngine;

public class BeforeTutorialState : GameState
{
    public override eGameStateID ID => eGameStateID.BeforeTutorial;

    public override bool CanTransitionTo(eGameStateID nextState)
    {
        return nextState == eGameStateID.Tutorial;
    }
}
