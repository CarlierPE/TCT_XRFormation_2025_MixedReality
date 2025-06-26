using UnityEngine;

public class Elevator : TriggerableByPlayer
{
    public void TouchElevator()
    {
        OnTriggeredByPlayer(eMonitoredAction.TouchElevator);
    }
}
