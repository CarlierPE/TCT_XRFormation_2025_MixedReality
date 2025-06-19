using FireSim.SSM;
using UnityEngine;

public class AfterSimulationState : GameState
{
    public override eGameStateID ID => eGameStateID.AfterSimulation;

    public override bool CanTransitionTo(eGameStateID nextState)
    {
        throw new System.NotImplementedException();
    }
}
