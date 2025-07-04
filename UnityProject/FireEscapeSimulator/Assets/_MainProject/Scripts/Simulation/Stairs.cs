using UnityEngine;

public class Stairs : TriggerableByPlayer
{

    private eMonitoredAction _action;
    public void UpStair()
    {
        _action = eMonitoredAction.StairsUp;
        OnTriggeredByPlayer(_action);
    }
    public void DownStair()
    {
        _action = eMonitoredAction.FinishLine;
        OnTriggeredByPlayer(_action);
    }
}
