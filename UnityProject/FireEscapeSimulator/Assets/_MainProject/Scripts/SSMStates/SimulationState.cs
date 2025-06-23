using FireSim.SSM;
using UnityEngine;

public class SimulationState : ScriptBasedGameState
{
    public SimulationState(MonoBehaviour script) : base(script) { }

    public override eGameStateID ID => eGameStateID.Simulation;

    public override bool CanTransitionTo(eGameStateID nextState)
    {
        return nextState == eGameStateID.AfterSimulation;
    }
}
