using TcT.FireSim.SSM;
using UnityEngine;

namespace TcT.FireSim
{
    public class SimulationDebugScript : MonoBehaviour
    {
        private StateMachine _stateMachine;
        [Header("Main component of each game state")]
        [SerializeField] BeforeSimulation _beforeSimulationScript;
        [SerializeField] Simulation _simulationScript;
        [SerializeField] AfterSimulation _afterSimulationScript;
        [SerializeField] Debriefing _debriefingScript;

        private static SimulationDebugScript _instance;

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
                    .AddState(new BeforeSimulationState(_beforeSimulationScript))
                    .AddState(new SimulationState(_simulationScript))
                    .AddState(new AfterSimulationState(_afterSimulationScript))
                    .AddState(new DebriefingState(_debriefingScript));

        }

        private void Start()
        {
            _stateMachine.SetInitialState(eGameStateID.BeforeSimulation);
        }

        private void OnEnable()
        {

            _beforeSimulationScript.OnSimulationStarting.AddListener(OnSimulationStarting);
            _simulationScript.OnSimulationEnding.AddListener(OnSimulationEnding);
            _afterSimulationScript.OnSimulationEnded.AddListener(OnSimulationEnded);

            _debriefingScript.OnDebriefingExited.AddListener(OnGameReset);
        }

        private void OnDisable()
        {

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
}