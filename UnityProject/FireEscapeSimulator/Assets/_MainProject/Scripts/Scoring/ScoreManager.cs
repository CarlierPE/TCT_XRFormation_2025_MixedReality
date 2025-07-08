using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{ 

    static ScoreManager _instance;

    private int _totalscore = 0;

    [SerializeField] List<TriggerableByPlayer> _triggerables = new();
    private List<ScoreLog> _logs = new();

    public int Score => _totalscore;
    public IEnumerable<ScoreLog> ScoreLogs => _logs.AsEnumerable();

    public UnityEvent OnGameIsFinished;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }    

        _instance = this;
    }

    public void StartScoreSystem()
    {
        //TODO
    }

    public void StopScoreSystem()
    {
        //TODO
    }

    private void OnEnable()
    {
        foreach (var triggerable in _triggerables)
        {
            triggerable.Triggered.AddListener(OnActionTriggered);
        }
    }

    private void OnDisable()
    {
        foreach (var triggerable in _triggerables)
        {
            triggerable.Triggered.RemoveListener(OnActionTriggered);
        }
    }
    public void InitScore()
    {
        _totalscore = 0;
    }

    private void OnActionTriggered(eMonitoredAction action)
    {
        //TODO -> appeler le save action avec le bon timer
    }

    private void SaveActionScore(eMonitoredAction action, float timeAction)
    {

        
        if (ScoreAction.tableScoreAction.TryGetValue(action, out int score))
        {
            _totalscore += score;
            ScoreLog log = new()
            {
                timeAction = timeAction,
                action = action,
                scoreValid = score
            };

            _logs.Add(log);
        }
    }
}