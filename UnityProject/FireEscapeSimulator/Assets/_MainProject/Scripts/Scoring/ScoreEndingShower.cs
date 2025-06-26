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

    private readonly ScoreAction _scoreAction = new ();


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

        _player = new();
    
        _totalscore = 0;

        _player = new();
    }

    public void SaveActionScore(eMonitoredAction action, float timeAction)
    {
        ScoreLog log = new()
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

        _player.scoreLogs.Add(log);

        if (action == eMonitoredAction.FinishLine)
        {
            _player.timeGame = timeAction;
            _player.scoreEnd = _totalscore;

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