//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class Seb_TestScore : MonoBehaviour
//{
//    public InputActionReference startGame;
//    public InputActionReference endGame;
//    public InputActionReference score;

//    public static Seb_TestScore Instance;

//    private List<ScoreLog> historicActions = new();

//    private float timeStarted;
//    private bool isStartGame;
//    private bool isfinishGame;
//    private int totalScore = 0;

//    [SerializeField] private TextMeshProUGUI endPanel;
//    [SerializeField] private TextMeshProUGUI timePanel;
//    [SerializeField] private TextMeshProUGUI history;

//    private SaveOnFile saveOnFile;
//    private GameDebriefing _player;

//    private readonly Dictionary<eMonitoredAction, int> actionScores = new()
//    {
//        { eMonitoredAction.OpenAlarmBox, 0 },
//        { eMonitoredAction.PressAlarmButton, 300 },
//        { eMonitoredAction.WalkIntoFire, -150 },
//        { eMonitoredAction.CloseDoor, 20 },
//        { eMonitoredAction.OpenDoor, -10 },
//        { eMonitoredAction.FinishLine, 2500 },
//        // etc.
//    };

//    private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//        }
//        else
//        {
//            Destroy(gameObject);
//        }

//        saveOnFile = new();
//        saveOnFile.InitBased();

//        _player = new();

//        History();
//    }

//    private void Start()
//    {
//        startGame.action.performed += ctx => StartGame();
//        endGame.action.performed += ctx => EndGame();
//        score.action.performed += ctx => AddScore();
//    }

//    private void Update()
//    {
//        if (isStartGame)
//        {
//            timePanel.text = $"Temps écoulé : {Time.time - timeStarted:F3} secondes";
//        }
//        else if (isfinishGame)
//        {
//            timePanel.text = "Partie terminée \n Appuyez sur 'Y' pour recommencer";
//        }
//        else
//        {
//            timePanel.text = "Appuyez sur 'Y' pour commencer";
//        }
//    }

//    public void StartGame()
//    {
//        isStartGame = true;
//        isfinishGame = false;
//        timeStarted = Time.time;
//        totalScore = 0;
//        historicActions.Clear();

//        _player = new GameDebriefing(); // ⚠️ Très important : réinitialise ici
//    }

//    public void EndGame()
//    {
//        isStartGame = false;
//        isfinishGame = true;
//        ShowEndScreen();
//    }

//    public void AddScore()
//    {
//        int scoreIndex = UnityEngine.Random.Range(0, actionScores.Count);
//        eMonitoredAction action = (eMonitoredAction)scoreIndex;

//        ScoreLog newAction = new ScoreLog
//        {
//            timeAction = Time.time - timeStarted,
//            action = action,
//            scoreValid = actionScores[action]
//        };

//        SaveActionScore(newAction);
//    }

//    public void SaveActionScore(ScoreLog action)
//    {
//        if (actionScores.TryGetValue(action.action, out int score))
//        {
//            totalScore += score;
//        }
//        else
//        {
//            endPanel.text += "Rien ne fut trouvé\n";
//        }

//        historicActions.Add(action);

//        if (action.action == eMonitoredAction.FinishLine)
//        {
//            endPanel.text += $"Fin de la partie, score final : {totalScore}\n";
//            EndGame();
//        }
//        else
//        {
//            endPanel.text += $"Action enregistrée : {action.action} | Score : {action.scoreValid}\n";
//        }
//    }

//    public void RegisterAction(eMonitoredAction action)
//    {
//        if (actionScores.TryGetValue(action, out int points))
//        {
//            AddScore(points);
//        }
//        else
//        {
//            endPanel.text += "Pas de valeur de score définie pour l'action\n";
//        }

//        if (action == eMonitoredAction.FinishLine)
//        {
//            EndGame();
//        }
//    }

//    public void AddScore(int points)
//    {
//        totalScore += points;
//    }

//    public void ShowEndScreen()
//    {
//        _player.startGame = Time.time - timeStarted;
//        _player.scoreEnd = totalScore;
//        _player.scoreLogs = new List<ScoreLog>(historicActions);

//        endPanel.text = $"Partie terminée !\n" +
//                        $"Temps écoulé : {_player.startGame:F2} secondes\n" +
//                        $"Score final : {_player.scoreEnd}\n" +
//                        "Historique des actions sauvegardé.\n" +
//                        "Appuyez sur 'Y' pour recommencer\n";

//        timePanel.text = "Temps remis à zéro\n";

//        saveOnFile.SaveDocument(_player);

//        History();
//    }

//    public void AfficherLHistorique()
//    {
//        endPanel.text = "Historique des actions :\n";
//        foreach (var action in historicActions)
//        {
//            endPanel.text += $"Action : {action.action} | Score : {actionScores[action.action]}\n";
//        }
//        endPanel.text += $"Score final : {totalScore}\n";
//    }

//    public void History()
//    {
//        history.text = "Voici l'historique : \n";

//        List<GameDebriefing> historiq = saveOnFile.GetAllDebriefings();

//        if (historiq == null || historiq.Count == 0)
//        {
//            history.text += "Aucune partie n'a été jouée";
//            return;
//        }

//        history.text += $"Nombre de parties jouées : {historiq.Count}\n";

//        foreach (var item in historiq)
//        {
//            history.text += $"Temps du parcours : {item.startGame:F2}, Score final : {item.scoreEnd}\n";
//        }
//    }
//}
