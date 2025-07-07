using UnityEngine;

public class EmergencyExit : TriggerableByPlayer
{
    private void OnTriggerEnter(Collider other)
    {
        OnTriggeredByPlayer(eMonitoredAction.FinishLine);
    }
}
