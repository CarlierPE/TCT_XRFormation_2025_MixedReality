using UnityEngine;

public class DoorClose : TriggerableByPlayer
{
    private void OnTriggerEnter(Collider other)
    {
        OnTriggeredByPlayer(eMonitoredAction.CloseDoor);
    }
}