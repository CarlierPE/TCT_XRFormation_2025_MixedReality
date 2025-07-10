using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace TcT.FireSim
{

    /*
     * Script principal de la simulation
     * Devra gérer tout ce qui tourne autour:
     * - déclencher le départ et expansion du feu/fumée
     * - démarrer le timer et le scoring
     * - indiquer au scoring les actions prises par l'utilisateur
     * - indiquer que la simulation est terminée via un unityevent
     * */
    public class Simulation : MonoBehaviour
    {
        [HideInInspector]
        public UnityEvent OnSimulationEnding;
        [SerializeField] ScoreManager _scoreManager;
        [SerializeField] DoorManager _doorManager;
        [SerializeField] FireInstancate _fireManager;
        [SerializeField] List<GameObject> _simulationItems;

        private void OnEnable()
        {
            _simulationItems.ForEach(i => i.SetActive(true));
            
            _scoreManager.OnGameIsFinished.AddListener(EndGame);
            _doorManager.gameObject.SetActive(true);
            _doorManager.ResetDoors();
            _scoreManager.InitScore();
            _scoreManager.StartScoreSystem();
            _fireManager.ResetFire();
            _fireManager.StartFire();
        }

        private void OnDisable()
        {
            _simulationItems.ForEach(i => i.SetActive(false));

            _fireManager.ResetFire();
            _scoreManager.OnGameIsFinished.RemoveListener(EndGame);
            _doorManager.gameObject.SetActive(false);
            _scoreManager.StopScoreSystem();
        }

        private void EndGame()
        {
            OnSimulationEnding.Invoke();
        }
    }
}