using System;
using FireSim.SSM;
using UnityEngine;

public class CalibratedState : GameState
{
    public override eGameStateID ID => eGameStateID.Calibrated;
    private GameObject _calibrationConfirmationObject;
    public override bool CanTransitionTo(eGameStateID nextState)
    {
        return nextState == eGameStateID.Uncalibrated || nextState == eGameStateID.BeforeTutorial;
    }

    public CalibratedState(GameObject calibrationConfirmationObject)
    {
        if(calibrationConfirmationObject == null) throw new ArgumentNullException(nameof(calibrationConfirmationObject));
        _calibrationConfirmationObject = calibrationConfirmationObject;
    }

    public override void OnEnter()
    {
        _calibrationConfirmationObject.SetActive(true);
    }

    public override void OnExit()
    {
        _calibrationConfirmationObject.SetActive(false);
    }
}
