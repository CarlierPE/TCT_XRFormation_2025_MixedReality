using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


public class SimulationSript : MonoBehaviour
{
    [SerializeField] List<GameObject> _fires;
    [SerializeField] float _timeExpension;
    [SerializeField] GameObject _prefabExtincteur;
    [SerializeField] GameObject _prefabAlarm;
    [SerializeField] List<GameObject> _noEntry;
    [SerializeField] List<GameObject> _prefabDoor;
    [SerializeField] GameObject _prefabPhone;

    //eMonitoredAction _actoin;
    ScoreEndingShower _scoreGame;
    FireInstancate _fireInstancate;
    Victory _victory;
    float _startGame;
    

    private void Awake()
    {
        _fireInstancate = new();
        _scoreGame = new();
        _startGame = Time.time;

        if (_fires != null)
        {
            foreach (GameObject fire in _fires)
            {
                fire.SetActive(false);
            }
            _fireInstancate.InstantieFire(_fires);
        }
        if (_timeExpension == 0)
        {
            _timeExpension = 5f;
        }

        _scoreGame = new();
        _fireInstancate = new();
        _scoreGame = new();

    }


    public void OnStartSenario()
    {
        _fireInstancate.StartFire();
        _scoreGame.InitScore();
    }

    public void UpdateScoreSenario(ScoreLog score)
    {
        float actionTime = Time.time - _startGame;
        _victory.SetTime(actionTime);
        _scoreGame.SaveActionScore(score, actionTime);
    }
     public void PauseSimulation()
    {
        _fireInstancate.PauseFire();

    }

    public void StopSimulation()
    {
        _fireInstancate.ResetFire();
        
    }
}
