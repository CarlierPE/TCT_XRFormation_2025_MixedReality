using UnityEngine;

public class AlarmClickerScore : TriggerableByPlayer
{
    public AlarmClickerScore TheScore;


    void OnTriggerEnter(Collider other)
    {
        base.OnTriggeredByPlayer(eMonitoredAction.PressAlarmButton);
    }
}