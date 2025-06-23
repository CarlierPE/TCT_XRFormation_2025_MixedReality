using FireSim.SSM;
using UnityEngine;

public class BeforeSimulationState : ScriptBasedGameState
{
    public BeforeSimulationState(MonoBehaviour script) : base(script) { }

    public override eGameStateID ID => eGameStateID.BeforeSimulation;

    public override bool CanTransitionTo(eGameStateID nextState)
    {
        return nextState == eGameStateID.Simulation;
    }
}
