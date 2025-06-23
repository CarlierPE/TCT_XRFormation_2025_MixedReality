using FireSim.SSM;
using UnityEngine;

public class CalibratedState : GameState
{
    public override eGameStateID ID => eGameStateID.Calibrated;

    public override bool CanTransitionTo(eGameStateID nextState)
    {
        return nextState == eGameStateID.Uncalibrated || nextState == eGameStateID.BeforeTutorial;
    }
}
