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
        //TODO - Inject the proper gameobjects/scripts/whatever into the game states
        //I've put some gameobjects as examples, but we can pass whatever we need
        //UI, scripts...
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

    public void OnGameStarted()
    {
        _stateMachine.ChangeState(eGameStateID.Uncalibrated);
    }

    public void OnCalibrated()
    {
        _stateMachine.ChangeState(eGameStateID.Calibrated);
    }

    public void OnCalibrationConfirmed()
    {
        _stateMachine.ChangeState(eGameStateID.BeforeTutorial);
    }

    public void OnCalibrationInvalidated()
    {
        _stateMachine.ChangeState(eGameStateID.Uncalibrated);
    }

    public void OnTutorialStarting()
    {
        _stateMachine.ChangeState(eGameStateID.Tutorial);
    }

    public void OnTutorialEnding()
    {
        _stateMachine.ChangeState(eGameStateID.AfterTutorial);
    }

    public void OnTutorialEnded()
    {
        _stateMachine.ChangeState(eGameStateID.BeforeSimulation);
    }

    public void OnSimulationStarting()
    {
        _stateMachine.ChangeState(eGameStateID.Simulation);
    }

    public void OnSimulationEnding()
    {
        _stateMachine.ChangeState(eGameStateID.AfterSimulation);
    }

    public void OnSimulationEnded()
    {
        _stateMachine.ChangeState(eGameStateID.Debriefing);
    }

    public void OnGameReset()
    {
        _stateMachine.ChangeState(eGameStateID.Started);
    }
}


