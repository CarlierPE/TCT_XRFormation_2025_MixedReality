using FireSim.SSM;
using UnityEngine;

public class TEST_CalibrationMain : MonoBehaviour
{
    private StateMachine _stateMachine;
    [Header("Main component of each game state")]
    [SerializeField] Calibration _calibrationScript;//it needs more than a simple UI
    [SerializeField] CalibrationConfirmation _confirmCalibrationScript;//will be UI script

    private static TEST_CalibrationMain _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        _stateMachine = new StateMachine();

        _ = _stateMachine
                .AddState(new UncalibratedState(_calibrationScript))
                .AddState(new CalibratedState(_confirmCalibrationScript))
                .SetInitialState(eGameStateID.Uncalibrated);

    }

    private void OnEnable()
    {

        _calibrationScript.OnCalibration.AddListener(OnCalibrated);
        _confirmCalibrationScript.OnCalibrationValidated.AddListener(OnCalibrationConfirmed);
        _confirmCalibrationScript.OnCalibrationFailed.AddListener(OnCalibrationInvalidated);

    }

    private void OnDisable()
    {

        _calibrationScript.OnCalibration.RemoveListener(OnCalibrated);
        _confirmCalibrationScript.OnCalibrationValidated.RemoveListener(OnCalibrationConfirmed);
        _confirmCalibrationScript.OnCalibrationFailed.RemoveListener(OnCalibrationInvalidated);

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
