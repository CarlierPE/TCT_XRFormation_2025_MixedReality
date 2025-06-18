using FireSim.SSM;
using UnityEngine;

public class TutorialState : GameState
{
    public override eGameStateID ID => eGameStateID.Tutorial;

    public override bool CanTransitionTo(eGameStateID nextState)
    {
        throw new System.NotImplementedException();
    }
}
