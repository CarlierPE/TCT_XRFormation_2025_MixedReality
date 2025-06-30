using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("classe de test ne pas utiliser dans la scène finale")]
public class SimulationSript : MonoBehaviour
{
    const float _maxTime = 10f;

    [SerializeField] List<GameObject> _fires;
    [SerializeField] float _timeExpension;
    [SerializeField] GameObject _prefabExtincteur;
    [SerializeField] GameObject _prefabAlarm;
    [SerializeField] List<GameObject> _noEntry;
    [SerializeField] List<GameObject> _prefabDoor;
    [SerializeField] GameObject _prefabPhone;

    ScoreManager _scoreGame;
    FireInstancate _fireInstancate;

    //TriggerableByPlayer _triggerableByPlayer;

    float _startGame;
    float _timePause;
    bool _isPaused;
    bool _isPlaying;




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
        _timePause = 0f;

    }


    public void OnStartSenario()
    {
        _isPlaying = !_isPlaying;
        if (_isPlaying)
        {
            StartSimulation();
        }

    }

    public void StartSimulation()
    {
        _fireInstancate.StartFire();
        _scoreGame.InitScore();
        _isPaused = false;

        _startGame = Time.time; // Reset the start time when the simulation starts
    }

    public void PauseSimulation()
    {
        _isPaused = !_isPaused;
        if (_isPaused)
        {
            _fireInstancate.PauseFire();
            _timePause += Time.time - _startGame; // Store the time when the simulation is paused
        }


    }

    public void StopSimulation()
    {
        _fireInstancate.ResetFire();
        _isPaused = false;

    }

    private void Update()
    {
        if (_isPaused)
        {
            _timePause = Time.time - _timePause;
        }

        float elapsedTime = Time.time - _startGame - _timePause;

        if (elapsedTime < _maxTime)
        {
            _timeExpension = _timeExpension - (elapsedTime / 0.2f); // Ensure time expansion is within a reasonable range
        }

        _fireInstancate.SetInterval(_timeExpension);

    }

    private void UpdateScoreSenario(eMonitoredAction action)
    {
        float timeAction = Time.time - _startGame - _timePause;

        //_scoreGame.SaveActionScore(action, timeAction);
    }

    [Obsolete("ne jamais utiliser, tout est géré par events", true)]
    public void OnTriggerScore(eMonitoredAction action)
    {
        //if (_triggerableByPlayer != null)
        //{
        //    UpdateScoreSenario(action);
        //}

    }


}
