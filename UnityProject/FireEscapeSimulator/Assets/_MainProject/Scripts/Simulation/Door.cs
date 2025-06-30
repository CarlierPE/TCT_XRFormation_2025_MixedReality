using UnityEngine;

public class Door : TriggerableByPlayer
{
    private readonly SimulationSript _simulation; 
    private eMonitoredAction _action;

    public void OpenDoor()
    {
        _action = eMonitoredAction.OpenDoor;
        OnTriggeredByPlayer(_action);
        _simulation.OnTriggerScore(_action);
    }

    public void CloseDoor()
    {
        _action = eMonitoredAction.CloseDoor;
        OnTriggeredByPlayer(_action);
        _simulation.OnTriggerScore(_action);
    }
}
