using UnityEngine;

public class Extinguisher : TriggerableByPlayer
{
    private eMonitoredAction _action;
    public void TrapExtinguisher()
    {
        _action = eMonitoredAction.ExtinguisherTake;
        OnTriggeredByPlayer(_action);
    }

    public void PutOutTheFire()
    {
        _action = eMonitoredAction.ExtinguisherPutOut;
        OnTriggeredByPlayer(_action);
    }

}
