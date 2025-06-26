using UnityEditor;
using UnityEngine;
using FireSim.SSM;
public class MainGameScript : MonoBehaviour
{
    private StateMachine _stateMachine;
    [Header("Main component of each game state")]
    [SerializeField] StartScript _startingScript;//will be the UI script Shawn is working on and not a GameObject
    [SerializeField] Calibration _calibrationScript;//it needs more than a simple UI
    [SerializeField] CalibrationConfirmation _confirmCalibrationScript;//will be UI script
    [SerializeField] BeforeTutorial _beforeTutorialScript;//will maybe setup things, or do nothing but firing the next state
    [SerializeField] Tutorial _tutorialScript;
    [SerializeField] AfterTutorial _afterTutorialScript;
    [SerializeField] BeforeSimulation _beforeSimulationScript;
    [SerializeField] Simulation _simulationScript;
    [SerializeField] AfterSimulation _afterSimulationScript;
    [SerializeField] Debriefing _debriefingScript;
    
    private static MainGameScript _instance;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }    

        _instance = this;

        _stateMachine = new StateMachine();

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

    private void OnEnable()
    {
        _startingScript.OnSessionStart.AddListener(OnGameStarted);

        _calibrationScript.OnCalibration.AddListener(OnCalibrated);
        _confirmCalibrationScript.OnCalibrationValidated.AddListener(OnCalibrationConfirmed);
        _confirmCalibrationScript.OnCalibrationFailed.AddListener(OnCalibrationInvalidated);

        _beforeTutorialScript.OnTutorialStarting.AddListener(OnTutorialStarting);
        _tutorialScript.OnTutorialValidated.AddListener(OnTutorialEnded);
        _tutorialScript.OnTutorialFailed.AddListener(OnTutorialRepeat);
        _afterTutorialScript.OnTutorialEnded.AddListener(OnTutorialEnded);

        _beforeSimulationScript.OnSimulationStarting.AddListener(OnSimulationStarting);
        _simulationScript.OnSimulationEnding.AddListener(OnSimulationEnding);
        _afterSimulationScript.OnSimulationEnded.AddListener(OnSimulationEnded);

        _debriefingScript.OnDebriefingExited.AddListener(OnGameReset);
    }

    private void OnDisable()
    {
        _startingScript.OnSessionStart.RemoveListener(OnGameStarted);

        _calibrationScript.OnCalibration.RemoveListener(OnCalibrated);
        _confirmCalibrationScript.OnCalibrationValidated.RemoveListener(OnCalibrationConfirmed);
        _confirmCalibrationScript.OnCalibrationFailed.RemoveListener(OnCalibrationInvalidated);

        _beforeTutorialScript.OnTutorialStarting.RemoveListener(OnTutorialStarting);
        _tutorialScript.OnTutorialValidated.RemoveListener(OnTutorialEnded);
        _tutorialScript.OnTutorialFailed.RemoveListener(OnTutorialRepeat);
        _afterTutorialScript.OnTutorialEnded.RemoveListener(OnTutorialEnded);

        _beforeSimulationScript.OnSimulationStarting.RemoveListener(OnSimulationStarting);
        _simulationScript.OnSimulationEnding.RemoveListener(OnSimulationEnding);
        _afterSimulationScript.OnSimulationEnded.RemoveListener(OnSimulationEnded);

        _debriefingScript.OnDebriefingExited.RemoveListener(OnGameReset);
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

    public void OnTutorialRepeat()
    {
        _stateMachine.ChangeState(eGameStateID.BeforeTutorial);
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


