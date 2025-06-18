using FireSim.SSM;
using UnityEngine;

public class SimulationState : GameState
{
    public override eGameStateID ID => eGameStateID.Simulation;

    public override bool CanTransitionTo(eGameStateID nextState)
    {
        throw new System.NotImplementedException();
    }
}
