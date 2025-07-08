using UnityEngine;

public class OpenAlarmBox : TriggerableByPlayer
{
    private void OnTriggerEnter(Collider other)
    {
        OnTriggeredByPlayer(eMonitoredAction.OpenAlarmBox);
    }
}
