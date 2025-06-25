using Meta.WitAi.Speech;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class Victory : TriggerableByPlayer
{
    public ScoreEndingShower TheEndingShower;
    private float _endTime;

    void OnTriggerEnter(Collider other)
    {
        base.OnTriggeredByPlayer(eMonitoredAction.FinishLine);
        TheEndingShower.ShowEndScreen(_endTime);
    }

    public void SetTime(float time)
    { _endTime = time; }
}
