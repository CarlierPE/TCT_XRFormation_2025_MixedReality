using UnityEngine;

public class Phone : TriggerableByPlayer
{
    private eMonitoredAction _action;

    public void TakePhone()
    {
        _action = eMonitoredAction.TakePhone;
        OnTriggeredByPlayer(_action);
    }
    public void Appel()
    {
        _action = eMonitoredAction.Appel;
        OnTriggeredByPlayer(_action);
    }
}
