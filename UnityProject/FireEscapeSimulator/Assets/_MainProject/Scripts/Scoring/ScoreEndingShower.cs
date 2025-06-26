using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ScoreEndingShower : MonoBehaviour
{
    
    public static ScoreEndingShower Instance;
    private List<ScoreLog> historicActions = new();

    private float timeStarted;

    bool isStartGame;
    bool isfinishGame;
    private int _totalscore = 0;
    private SaveOnFile saveOnFile = new();
    private GameDebriefing _player;

    private Dictionary<eMonitoredAction, int> actionScores = new Dictionary<eMonitoredAction, int>()
     {
         { eMonitoredAction.OpenAlarmBox, 0 },
         { eMonitoredAction.PressAlarmButton, 300 },
         { eMonitoredAction.WalkIntoFire, -150 }, 
         { eMonitoredAction.CloseDoor, 20 },
         { eMonitoredAction.OpenDoor, -10 },
         { eMonitoredAction.FinishLine, 2500 },
         // etc.
     };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        saveOnFile = new SaveOnFile();
        saveOnFile.InitBased();

        _player = new GameDebriefing();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void StartGame()
    {
        isStartGame = true;
        isfinishGame = false;
        timeStarted = Time.time;
        _totalscore = 0;
        historicActions.Clear();

        _player = new GameDebriefing(); 
    }

    private void EndGame()
    {
        isStartGame = false;
        isfinishGame = true;
        ShowEndScreen();
    }

    public void SaveActionScore(ScoreLog action)
    {
        if (actionScores.TryGetValue(action.action, out int score))
        {
            _totalscore += score;
        }

        historicActions.Add(action);

        if (action.action == eMonitoredAction.FinishLine)
        {
            EndGame();
        }
    }

    public void ShowEndScreen()
    {
        _player.startGame = Time.time - timeStarted;
        _player.scoreEnd = _totalscore;
        _player.scoreLogs = new List<ScoreLog>(historicActions);

        saveOnFile.SaveDocument(_player);
    }

    public string History()
    {
        string history;
        history = "Voici l'historique : \n";

        List<GameDebriefing> historiq = saveOnFile.GetAllDebriefings();

        if (historiq == null || historiq.Count == 0)
        {
            history += "Aucune partie n'a été jouée";
            return history;
        }

        history += $"Nombre de parties jouées : {historiq.Count}\n";

        foreach (var item in historiq)
        {
            history += $"Temps du parcours : {item.startGame:F3}, Score final : {item.scoreEnd}\n";
        }

        return history;
    }
}
    

