using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreEndingShower : MonoBehaviour
{
    public static ScoreEndingShower Instance;
    
    public GameObject endPanel;
    
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
    private int score = 0;
    

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
        score += points;
       
    }

    public void SubtractScore(int amount)
    {
        score = Mathf.Max(0, score - amount);
       
    }

    public void ShowEndScreen()
    {
        endPanel.SetActive(true);
        
           // SaveOnFile.save;
        }
    }
    

