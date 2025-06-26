using System;
using FireSim.SSM;
using UnityEngine;

public class StartedState : ScriptBasedGameState
{
    public StartedState(MonoBehaviour script) : base(script) { }

    public override eGameStateID ID => eGameStateID.Started;

    public override bool CanTransitionTo(eGameStateID nextState)
    {
        return nextState == eGameStateID.Uncalibrated;
    }
}
