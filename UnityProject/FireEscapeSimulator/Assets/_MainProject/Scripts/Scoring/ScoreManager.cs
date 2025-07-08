using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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

    private float _timer;
    public float timeMax;

    private GameDebriefing _gameDebriefing;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        _gameDebriefing = new GameDebriefing();

    }

    public void StartScoreSystem()
    {
        //TODO
        _timer = Time.time;
    }

    public void StopScoreSystem()
    {
        //TODO
        _timer = Time.time - _timer;
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
        StartScoreSystem();
    }

    private void OnActionTriggered(eMonitoredAction action)
    {
        //TODO -> appeler le save action avec le bon timer

        float timerAction;

        if (ScoreAction.tableScoreAction.TryGetValue(action, out int score))
        {
            timerAction = Time.time - _timer;

            if (action == eMonitoredAction.FinishLine)
            {
                StopScoreSystem();
                SaveActionScore(action, score, timerAction);
                SaveFinalScore(timerAction);
            }
            else if(action == eMonitoredAction.WalkIntoFire || action == eMonitoredAction.TimerOut)
            {
                StopScoreSystem();
                score = -_totalscore;
                SaveActionScore(action, score, timerAction);
                SaveFinalScore(timerAction);
            }
            else
                SaveActionScore(action, score, timerAction);
        }

    }

    private void SaveActionScore(eMonitoredAction action, int score, float time)
    {
        
            _totalscore += score;
            ScoreLog log = new()
            {
                timeAction = time,
                action = action,
                scoreValid = score
            };

            _logs.Add(log);
    }

    private void SaveFinalScore(float time)
    {
        _gameDebriefing.timeGame = time;
        _gameDebriefing.scoreEnd = _totalscore;
        _gameDebriefing.scoreLogs = _logs;

        //SaveOnDocument(_gameDebriefing);
    }

    public string ReadingDebriefing()
    {
        string debriefing= $"Votre temps de simulation est : {_gameDebriefing.timeGame}, et le total des points est : {_gameDebriefing.scoreEnd}\n\n";

        debriefing += "voici les points en detail avec le temps et l'action realiser : \n";

        foreach (var item in _logs)
        {
            debriefing += $"\tpoint : {item.scoreValid} | temps : {item.timeAction} | action : {item.action} \n ";
        }

        return debriefing;
    }

    [Obsolete("on n'utilise pas pour le moment")]
    private void SaveOnDocument(GameDebriefing debriefing)
    {
        SaveOnFile saveOnFile = new();

        saveOnFile.InitBased();

        saveOnFile.SaveDocument(debriefing);
        
    }
}