using System;
using FireSim.SSM;
using UnityEngine;

public class StartedState : GameState
{
    public override eGameStateID ID => eGameStateID.Started;

    public override bool CanTransitionTo(eGameStateID nextState)
    {
        return nextState == eGameStateID.Uncalibrated;
    }

    private GameObject _startingUI;
    public StartedState(GameObject startingObject)
    {
        if(startingObject == null)
            throw new ArgumentNullException(nameof(startingObject));
        this._startingUI = startingObject;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _startingUI.SetActive(true);
    }

    public override void OnExit()
    {
        _startingUI.SetActive(false);
    }
}
