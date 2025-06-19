using FireSim.SSM;
using UnityEngine;

public class StartedState : GameState
{
    public override eGameStateID ID => eGameStateID.Started;

    public override bool CanTransitionTo(eGameStateID nextState)
    {
        throw new System.NotImplementedException();
    }
}
