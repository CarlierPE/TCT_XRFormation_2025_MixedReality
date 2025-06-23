using System;
using FireSim.SSM;
using UnityEngine;
using UnityEngine.InputSystem;

public class UncalibratedState : ScriptBasedGameState
{
    public override eGameStateID ID => eGameStateID.Uncalibrated;
    public override bool CanTransitionTo(eGameStateID nextState)
    {
        return nextState == eGameStateID.Calibrated;
    }
    public UncalibratedState(MonoBehaviour calibrationScript) : base(calibrationScript) { }
}
