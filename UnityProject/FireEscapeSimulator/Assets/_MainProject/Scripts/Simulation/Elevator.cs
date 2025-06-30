using UnityEngine;

public class Elevator : TriggerableByPlayer
{
    private readonly SimulationSript _simulation;

    public void TouchElevator()
    {
        eMonitoredAction action = eMonitoredAction.TouchElevator;
        OnTriggeredByPlayer(action);
        _simulation.OnTriggerScore(action);
    }
}
