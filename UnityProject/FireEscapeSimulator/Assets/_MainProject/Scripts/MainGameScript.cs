using UnityEditor;
using UnityEngine;
using FireSim.SSM;
using Ldm.Relocator;
[RequireComponent(typeof(AnchorBasedRelocator))]
public class MainGameScript : MonoBehaviour
{
    private StateMachine _stateMachine;
    [Header("Main component of each game state")]
    [SerializeField] GameObject _startingObject;
    [SerializeField] GameObject _calibrationObject;
    [SerializeField] GameObject _confirmCalibrationObject;
    AnchorBasedRelocator _relocator;
    private void Awake()
    {
        _relocator = GetComponent<AnchorBasedRelocator>();
    }
    void Start()
    {
        _stateMachine = new StateMachine();
        //TODO - Injecter dans chaque état son/ses gameobjects propres
        _ = _stateMachine
                .AddState(new StartedState(_startingObject))
                .AddState(new UncalibratedState(_calibrationObject))
                .AddState(new CalibratedState(_confirmCalibrationObject))
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
        _stateMachine.OnUpdate();
    }
}


