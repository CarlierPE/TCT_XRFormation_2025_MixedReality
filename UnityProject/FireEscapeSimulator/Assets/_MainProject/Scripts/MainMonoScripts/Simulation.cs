using UnityEngine;
using UnityEngine.Events;

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

    private void OnEnable()
    {
        _scoreManager.OnGameIsFinished.AddListener(EndGame);
        _doorManager.gameObject.SetActive(true);
        _doorManager.ResetDoors();
        _scoreManager.InitScore();
        _scoreManager.StartScoreSystem();
    }

    private void OnDisable()
    {
        _scoreManager.OnGameIsFinished.RemoveListener(EndGame);
        _doorManager.gameObject.SetActive(false);
        _scoreManager.StopScoreSystem();
    }

    private void EndGame()
    {
        OnSimulationEnding.Invoke();
    }
}
