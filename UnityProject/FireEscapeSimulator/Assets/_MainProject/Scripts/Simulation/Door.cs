using UnityEngine;

public class Door : TriggerableByPlayer
{
    public void OpenDoor()
    {
        OnTriggeredByPlayer(eMonitoredAction.OpenDoor);
    }

    public void CloseDoor()
    {
        OnTriggeredByPlayer(eMonitoredAction.CloseDoor);
    }
}
