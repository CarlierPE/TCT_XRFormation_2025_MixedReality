using System;
using Unity.VisualScripting;
using UnityEngine;

public class Victory : TriggerableByPlayer
{
    public ScoreEndingShower TheEndingShower;
   

    void OnTriggerEnter(Collider other)
    {
        base.OnTriggeredByPlayer(eMonitoredAction.FinishLine);
        TheEndingShower.ShowEndScreen();
    }
}
