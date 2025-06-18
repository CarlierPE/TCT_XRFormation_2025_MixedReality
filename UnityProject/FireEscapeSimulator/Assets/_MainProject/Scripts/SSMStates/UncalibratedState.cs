using FireSim.SSM;
using UnityEngine;

public class UncalibratedState : GameState
{
    public override eGameStateID ID => eGameStateID.Uncalibrated;

    public override bool CanTransitionTo(eGameStateID nextState)
    {
        throw new System.NotImplementedException();
    }
}
