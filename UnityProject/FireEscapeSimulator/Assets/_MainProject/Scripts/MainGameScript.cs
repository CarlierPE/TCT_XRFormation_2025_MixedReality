using UnityEditor;
using UnityEngine;
using FireSim.SSM;
public class MainGameScript : MonoBehaviour
{
    private StateMachine _stateMachine;
    [Header("Main component of each game state")]
    [SerializeField] MonoBehaviour _startingScript;//will be the UI script Shawn is working on and not a GameObject
    [SerializeField] MonoBehaviour _calibrationScript;//it needs more than a simple UI
    [SerializeField] MonoBehaviour _confirmCalibrationScript;//will be UI script
    [SerializeField] MonoBehaviour _beforeTutorialScript;//will maybe setup things, or do nothing but firing the next state
    [SerializeField] MonoBehaviour _tutorialScript;
    [SerializeField] MonoBehaviour _afterTutorialScript;
    [SerializeField] MonoBehaviour _beforeSimulationScript;
    [SerializeField] MonoBehaviour _simulationScript;
    [SerializeField] MonoBehaviour _afterSimulationScript;
    [SerializeField] MonoBehaviour _debriefingScript;

    void Start()
    {
        _stateMachine = new StateMachine();
        //TODO - Inject the proper gameobjects/scripts/whatever into the game states
        //I've put some gameobjects as examples, but we can pass whatever we need
        //UI, scripts...
        _ = _stateMachine
                .AddState(new StartedState(_startingScript))
                .AddState(new UncalibratedState(_calibrationScript))
                .AddState(new CalibratedState(_confirmCalibrationScript))
                .AddState(new BeforeTutorialState(_beforeTutorialScript))
                .AddState(new TutorialState(_tutorialScript))
                .AddState(new AfterTutorialState(_afterTutorialScript))
                .AddState(new BeforeSimulationState(_beforeSimulationScript))
                .AddState(new SimulationState(_simulationScript))
                .AddState(new AfterSimulationState(_afterSimulationScript))
                .AddState(new DebriefingState(_debriefingScript))
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


