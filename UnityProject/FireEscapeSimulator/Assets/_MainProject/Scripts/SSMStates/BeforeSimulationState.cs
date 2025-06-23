using FireSim.SSM;
using UnityEngine;

public class BeforeSimulationState : GameState
{
    public override eGameStateID ID => eGameStateID.BeforeSimulation;

    public override bool CanTransitionTo(eGameStateID nextState)
    {
        return nextState == eGameStateID.Simulation;
    }
}
