using UnityEngine;
using UnityEngine.Events;

namespace TcT.FireSim
{
    /*
    * Ce script doit préparer le terrain pour le script simulation
    * Encore à déterminer
    * Doit déclencher un UnityEvent à la fin de son travail
    * */
    public class BeforeSimulation : MonoBehaviour
    {
        [HideInInspector]
        public UnityEvent OnSimulationStarting;

        [SerializeField] TriggerableByPlayer _simulationStarter;

        private void OnEnable()
        {
            _simulationStarter.gameObject.SetActive(true);
            _simulationStarter.Triggered.AddListener(StartSimulation);
        }

        private void OnDisable()
        {
            _simulationStarter.gameObject.SetActive(false);
            _simulationStarter.Triggered.RemoveListener(StartSimulation);
        }

        private void StartSimulation(eMonitoredAction _)
        {
            OnSimulationStarting.Invoke();
        }
    }
}