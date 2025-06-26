using UnityEngine;

public class EmergencyExit : TriggerableByPlayer
{
    public void EntryEmergnecyExit()
    {
        OnTriggeredByPlayer(eMonitoredAction.FinishLine);
    }
}
