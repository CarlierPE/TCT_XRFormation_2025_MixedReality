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
    public InputActionReference startGame;
    public InputActionReference endGame;
    public InputActionReference score;
    public static ScoreEndingShower Instance;
    private List<ScoreLog> historicActions = new List<ScoreLog>();

    private float timeStarted;

    public TextMeshProUGUI endPanel;
    public TextMeshProUGUI timePanel;
    public TextMeshProUGUI history;
    bool isStartGame;
    bool isfinishGame;
    private int Totalscore = 0;
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

    public void SaveActionScore(ScoreLog action)
    {

        if (actionScores.TryGetValue(action.action, out int score))
        {
            Totalscore += score;
        }
        else
        {
            endPanel.text += ("Rien ne fut trouvé ");
        }

        historicActions.Add(action);

        if(action.action == eMonitoredAction.FinishLine)
        {
            endPanel.text += ($"Fin de la partie, score final : {Totalscore}");
            EndGame();

        }
        else
        {
            endPanel.text += ($"Action enregistrée : {action.action} | Score : {action.scoreValid}");
        }
    }

    public void AfficherLHistorique()
    {
        endPanel.text = "Historique des actions :\n";
        foreach (var action in historicActions)
        {
            endPanel.text += $"Action : {action} |  score : {actionScores[action.action]}\n";
        }
        endPanel.text += ($"FinalScore : {Totalscore}\n");
    }
    

    private void Awake()
    {
        saveOnFile.InitBased();
        
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
        


        History();
    }

    public void AddScore()
    {
        int scoreValue = Random.Range(0, actionScores.Count); // Example score value

        RegisterAction((eMonitoredAction)scoreValue);

        ScoreLog newAction = new ScoreLog
        {
            timeAction = Time.time - timeStarted,
            action = (eMonitoredAction)scoreValue,
            scoreValid = actionScores[(eMonitoredAction)scoreValue]
        };
        SaveActionScore(newAction);
    }
    
    private void Start()
    {
        startGame.action.performed += ctx => StartGame();
        endGame.action.performed += ctx => EndGame();
        score.action.performed += ctx => AddScore();
    }

    private void Update()
    {
        
        if (actionScores.ContainsKey(action))
        {
            int points = actionScores[action];

            AddScore(points);;
        }
        else
        {
            endPanel.text += "pas de valeur de score définie pour l'action";
        }
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
        Totalscore = 0;
        historicActions.Clear();
        saveOnFile = new();
    }

    public void EndGame()
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
        AfficherLHistorique();
    }

    public void AddScore(int points)
    {
        Totalscore += points;
    }

    public void ShowEndScreen()
    {           
        GetGameDebriefing();
        
        timeStarted = Time.time - timeStarted;
        timePanel.text = "Temps remit à zero\n";

        endPanel.text = $"Partie terminée !\n" +
                        $"Temps écoulé : {timeStarted:F2} secondes\n" +
                        $"Score final : {Totalscore}\n" +
                        "Historique des actions sauvegardé.\n" +
                        "Appuyez sur 'Y' pour recommencer";


        saveOnFile.SaveDocument(_player);
        
        History();
    }

    public void History()
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
        history.text = "Voici l'historique : \n";

        List<GameDebriefing> historiq = saveOnFile.GetAllDebriefings();

        if (historiq.Count == 0 || historiq == null)
        {
            history.text += "Aucune partie n'a été jouée";
            return;
        }

        history.text += $"Nombre de parties jouées : {historiq.Count}\n";

        foreach (var item in historiq)
        {
            history.text += $"Temps du parcours : {item.startGame}, Score final : {item.scoreEnd}\n";
        }

    }

    private void GetGameDebriefing()
    {
        _player = new GameDebriefing
        {
            startGame = timeStarted,
            scoreEnd = Totalscore,
            scoreLogs = historicActions
        };
        
    }

    private void Update()
    {
        if (isStartGame)
        {
            timePanel.text = $"Temps écoulé : {Time.time - timeStarted:F3} secondes";
        }
        else if (isfinishGame)
        {
            timePanel.text = "Partie terminée \n Appuyez sur 'Y' pour recommencer";
            History();
        }
        else
        {
            timePanel.text = "Appuyez sur 'Y' pour commencer";
        }
    }
}
    

