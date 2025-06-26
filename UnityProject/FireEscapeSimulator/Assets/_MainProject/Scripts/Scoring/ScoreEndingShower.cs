using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ScoreEndingShower : MonoBehaviour
{

    public static ScoreEndingShower Instance;

    private int _totalscore = 0;
    private SaveOnFile saveOnFile = new();
    private GameDebriefing _player;
    private List<ScoreLog> historicActions = new();

    private IScoreAction _scoreAction = new ();


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

        _player = new GameDebriefing();
        historicActions.Clear();
    }

    public void SaveActionScore(eMonitoredAction action, float timeAction)
    {
        ScoreLog log = new ScoreLog
        {
            timeAction = timeAction,
            action = action,
            scoreValid = 0 // Will be updated below
        };

        
        if (_scoreAction.tableScoreAction.TryGetValue(action, out int score))
        {
            _totalscore += score;
            log.scoreValid = score;
        }

        historicActions.Add(log);

        if (action == eMonitoredAction.FinishLine)
        {
            _player.timeGame = timeAction;
            _player.scoreEnd = _totalscore;
            _player.scoreLogs = historicActions;

            ShowEndScreen();
        }
    }

    public void ShowEndScreen()
    {
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
            history += $"Temps du parcours : {item.timeGame:F3}, Score final : {item.scoreEnd}\n";
        }

        return history;
    }
}