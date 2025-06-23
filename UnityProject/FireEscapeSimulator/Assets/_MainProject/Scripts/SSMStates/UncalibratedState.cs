using System;
using FireSim.SSM;
using UnityEngine;

public class UncalibratedState : GameState
{
    public override eGameStateID ID => eGameStateID.Uncalibrated;
    private GameObject _calibrationObject;
    public override bool CanTransitionTo(eGameStateID nextState)
    {
        return nextState == eGameStateID.Calibrated;
    }

    public override void OnEnter()
    {
        _calibrationObject.SetActive(true);
    }

    public override void OnExit()
    {
        _calibrationObject.SetActive(false);
    }

    public UncalibratedState(GameObject calibrationObject)
    {
        if(calibrationObject == null) throw new ArgumentNullException(nameof(calibrationObject));

        _calibrationObject = calibrationObject;
    }
}
