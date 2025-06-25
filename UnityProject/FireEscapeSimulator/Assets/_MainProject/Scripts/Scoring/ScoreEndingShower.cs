using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ScoreEndingShower : MonoBehaviour
{

    const float _maxTime = 10f;
    public static ScoreEndingShower Instance;
    private List<ScoreLog> historicActions = new();

    private int _totalscore = 0;
    private SaveOnFile saveOnFile = new();
    private GameDebriefing _player;

    private Dictionary<eMonitoredAction, int> actionScores = new ()
     {
         { eMonitoredAction.OpenAlarmBox, 0 },
         { eMonitoredAction.PressAlarmButton, 300 },
         { eMonitoredAction.WalkIntoFire, -150 }, 
         { eMonitoredAction.CloseDoor, 20 },
         { eMonitoredAction.OpenDoor, -10 },
         { eMonitoredAction.FinishLine, 2500 },
         // etc.
     };

    public void InitScore()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        saveOnFile = new();
        saveOnFile.InitBased();

        _player = new GameDebriefing();
    
        _totalscore = 0;
        historicActions.Clear();

        _player = new GameDebriefing(); 
    }

    public void SaveActionScore(ScoreLog action, float elapsedTime)
    {
        if (actionScores.TryGetValue(action.action, out int score))
        {
            _totalscore += score;
        }

        historicActions.Add(action);

        if (action.action == eMonitoredAction.FinishLine || elapsedTime == _maxTime)
        {
            ShowEndScreen(elapsedTime);
        }
    }

    public void ShowEndScreen(float elapsedTime)
    {
        _player.startGame = elapsedTime;
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
    

