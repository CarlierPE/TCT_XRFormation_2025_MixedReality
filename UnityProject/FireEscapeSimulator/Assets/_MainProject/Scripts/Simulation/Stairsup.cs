using UnityEngine;

public class StairsUp : TriggerableByPlayer
{

    private eMonitoredAction _action;
    public void UpStair()
    {
        _action = eMonitoredAction.StairsUp;
        OnTriggeredByPlayer(_action);
    }
}
