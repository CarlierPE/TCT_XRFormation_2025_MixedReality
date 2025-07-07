using UnityEngine;

public class Elevator : TriggerableByPlayer
{
    private void OnTriggerEnter(Collider other)
    {
        OnTriggeredByPlayer(eMonitoredAction.TouchElevator);
    }
}
