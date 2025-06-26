using UnityEngine;

public class Stairs : TriggerableByPlayer
{
    public void UpStair()
    {
        OnTriggeredByPlayer(eMonitoredAction.StairsUp);
    }
    public void DownStair()
    {
        OnTriggeredByPlayer(eMonitoredAction.FinishLine);
    }
}
