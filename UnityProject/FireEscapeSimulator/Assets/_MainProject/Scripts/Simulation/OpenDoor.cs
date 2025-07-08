using UnityEngine;

public class OpenDoor : TriggerableByPlayer
{
    private void OnTriggerEnter(Collider other)
    {
        OnTriggeredByPlayer(eMonitoredAction.OpenDoor);
    }
}
