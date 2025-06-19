using UnityEditor;
using UnityEngine;
using FireSim.SSM;
public class MainGameScript : MonoBehaviour
{
    private StateMachine _stateMachine;

    void Start()
    {
        _stateMachine = new StateMachine();
        _ = _stateMachine.AddState(new AfterSimulationState())
                        .AddState(new AfterTutorialState())
                        .AddState(new BeforeSimulationState())
                        .AddState(new BeforeTutorialState())
                        .AddState(new CalibratedState())
                        .AddState(new DebriefingState())
                        .AddState(new SimulationState())
                        .AddState(new StartedState())
                        .AddState(new TutorialState())
                        .AddState(new UncalibratedState())
                        .SetInitialState(eGameStateID.Started);
    }

    void Update()
    {
        _stateMachine.Update();
    }
}


