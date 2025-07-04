using UnityEngine;

public class EmergencyExit : TriggerableByPlayer
{
    public void EntryEmergnecyExit()
    {
        eMonitoredAction action = eMonitoredAction.FinishLine;
        OnTriggeredByPlayer(action);
    }
}
