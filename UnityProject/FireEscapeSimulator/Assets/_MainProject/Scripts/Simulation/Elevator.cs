using UnityEngine;

public class Elevator : TriggerableByPlayer
{

    public void TouchElevator()
    {
        eMonitoredAction action = eMonitoredAction.TouchElevator;
        OnTriggeredByPlayer(action);
    }
}
