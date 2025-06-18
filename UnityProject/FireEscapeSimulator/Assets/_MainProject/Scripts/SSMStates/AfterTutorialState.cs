using FireSim.SSM;
using UnityEngine;

public class AfterTutorialState : GameState
{
    public override eGameStateID ID => eGameStateID.AfterTutorial;

    public override bool CanTransitionTo(eGameStateID nextState)
    {
        throw new System.NotImplementedException();
    }
}
