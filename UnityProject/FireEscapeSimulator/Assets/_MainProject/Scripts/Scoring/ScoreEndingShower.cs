using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreEndingShower : MonoBehaviour
{
    public static ScoreEndingShower Instance;
    private List<eMonitoredAction> historicActions = new List<eMonitoredAction>();
    
    public GameObject endPanel;
     private int Totalscore = 0;
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
 //public SaveOnFile saveOnFile;
 public void SaveActionScore(eMonitoredAction action)
 {
     historicActions.Add(action);
     if (actionScores.TryGetValue(action, out int score))
     {
         Totalscore += score;
         Debug.Log($"Enregistrement D'action en cours : {action} | Score : {score} | Totalscore : {Totalscore}");}
     else
     {
         Debug.LogWarning($"Rien ne fut trouvé : {action}");};
 }

 public void AfficherLHistorique()
 {
     foreach (var action in historicActions)
     {
         Debug.Log($"Action : {action} |  score : {actionScores[action]}");
     }
     Debug.Log ($"FinalScore : {Totalscore}");
 }
    

    private void Awake()
    {
        endPanel.SetActive(false);

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    

    private void Start()
    {
       
        if (endPanel != null)
            endPanel.SetActive(false);
    }

    public void RegisterAction(eMonitoredAction action)
    {
        if (actionScores.ContainsKey(action))
        {
            int points = actionScores[action];
            if (points > 0)
            AddScore(points);
            else
            SubtractScore(Mathf.Abs(points));
        }
        else
        {
            Debug.LogWarning("pas de valeur de score définie pour l'action");
        }
    }
    public void AddScore(int points)
    {
        Totalscore += points;
       
    }

    public void SubtractScore(int amount)
    {
        Totalscore = Mathf.Max(0, Totalscore - amount);
       
    }

    public void ShowEndScreen()
    {
        endPanel.SetActive(true);
        
           // SaveOnFile.save;
        }
    }
    

