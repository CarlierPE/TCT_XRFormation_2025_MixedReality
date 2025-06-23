using System;
using FireSim.SSM;
using UnityEngine;

public class BeforeTutorialState : ScriptBasedGameState
{
    public override eGameStateID ID => eGameStateID.BeforeTutorial;

    public override bool CanTransitionTo(eGameStateID nextState)
    {
        return nextState == eGameStateID.Tutorial;
    }

    public BeforeTutorialState(MonoBehaviour script) : base(script) { }
}
