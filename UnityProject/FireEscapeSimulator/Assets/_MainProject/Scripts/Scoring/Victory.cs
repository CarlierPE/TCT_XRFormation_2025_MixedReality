using Meta.WitAi.Speech;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class Victory : TriggerableByPlayer
{
    public ScoreManager TheEndingShower;

    void OnTriggerEnter(Collider other)
    {
        base.OnTriggeredByPlayer(eMonitoredAction.FinishLine);
    }

}
