using UnityEditor;
using UnityEngine;
using FireSim.SSM;
public class MainGameScript : MonoBehaviour
{
    private StateMachine _stateMachine;

    void Start()
    {
        _stateMachine = new StateMachine();
        //TODO - Injecter dans chaque état son/ses gameobjects propres
        _ = _stateMachine
                        .AddState(new StartedState())
                        .AddState(new UncalibratedState())
                        .AddState(new CalibratedState())
                        .AddState(new BeforeTutorialState())
                        .AddState(new TutorialState())
                        .AddState(new AfterTutorialState())
                        .AddState(new BeforeSimulationState())
                        .AddState(new SimulationState())
                        .AddState(new AfterSimulationState())
                        .AddState(new DebriefingState())
                        .SetInitialState(eGameStateID.Started);
    }

    private void Update()
    {
        
    }
}


