using UnityEngine;

public class StairsDown : TriggerableByPlayer
{

    private eMonitoredAction _action;

    public void DownStair()
    {
        _action = eMonitoredAction.FinishLine;
        OnTriggeredByPlayer(_action);
    }
}
