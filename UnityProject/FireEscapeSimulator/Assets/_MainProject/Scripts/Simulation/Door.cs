using UnityEngine;

public class Door : TriggerableByPlayer
{
    private eMonitoredAction _action;

    public void CloseDoor()
    {
        _action = eMonitoredAction.CloseDoor;
        OnTriggeredByPlayer(_action);
    }
}
