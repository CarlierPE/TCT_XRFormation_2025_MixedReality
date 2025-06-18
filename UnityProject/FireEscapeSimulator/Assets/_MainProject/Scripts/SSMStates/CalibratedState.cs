using FireSim.SSM;
using UnityEngine;

public class CalibratedState : GameState
{
    public override eGameStateID ID => eGameStateID.Calibrated;

    public override bool CanTransitionTo(eGameStateID nextState)
    {
        throw new System.NotImplementedException();
    }
}
