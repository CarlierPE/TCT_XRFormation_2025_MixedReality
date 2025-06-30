using UnityEngine;

public class EmergencyExit : TriggerableByPlayer
{
    private readonly SimulationSript _simulation;
    public void EntryEmergnecyExit()
    {
        eMonitoredAction action = eMonitoredAction.FinishLine;
        OnTriggeredByPlayer(action);
        _simulation.OnTriggerScore(action);
    }
}
