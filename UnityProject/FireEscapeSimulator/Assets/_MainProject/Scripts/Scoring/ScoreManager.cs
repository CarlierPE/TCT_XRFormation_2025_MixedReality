using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace TcT.FireSim
{

    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textDebriefing;

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

        private bool _isPlaying;
        float timerAction;

        private void Awake()
        {
            Debug.Log("entrer dans le Away");
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                Debug.Log("detruit l'instance");

                return;
            }

            _instance = this;
            _gameDebriefing = new GameDebriefing();
        }

        private void Update()
        {

            Debug.Log("entrer dans le Update");
            if (_isPlaying)
            {
                timerAction = Time.time - _timer;

                if (timerAction >= timeMax)
                {
                    _isPlaying = false;
                    OnActionTriggered(eMonitoredAction.TimerOut);
                }
            }
        }

        public void StartScoreSystem()
        {
            _timer = Time.time;
            _isPlaying = true;
        }

        public void StopScoreSystem()
        {
            _timer = Time.time - _timer;
            _isPlaying = false;
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
            if (ScoreAction.tableScoreAction.TryGetValue(action, out int score))
            {
                timerAction = Time.time - _timer;

                if (action == eMonitoredAction.FinishLine)
                {
                    StopScoreSystem();
                    SaveActionScore(action, score, timerAction);
                    SaveFinalScore(timerAction);
                }
                else if (action == eMonitoredAction.WalkIntoFire || action == eMonitoredAction.TimerOut)
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
            //TODO - fix ce truc
            //_textDebriefing.text += ReadingDebriefing();
            OnGameIsFinished.Invoke();
            //SaveOnDocument(_gameDebriefing);
        }

        public string ReadingDebriefing()
        {
            string debriefing = $"\nVotre temps de simulation est : {_gameDebriefing.timeGame}, et le total des points est : {_gameDebriefing.scoreEnd}\n\n";

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
}