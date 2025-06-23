using FireSim.SSM;
using UnityEngine;

public class DebriefingState : GameState
{
    public override eGameStateID ID => eGameStateID.Debriefing;

    public override bool CanTransitionTo(eGameStateID nextState)
    {
        return nextState == eGameStateID.Started;
    }
}
