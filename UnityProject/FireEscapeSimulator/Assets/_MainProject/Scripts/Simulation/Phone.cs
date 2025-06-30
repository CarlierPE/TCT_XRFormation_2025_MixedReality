using UnityEngine;

public class Phone : TriggerableByPlayer
{
    private readonly SimulationSript _simulation;
    private eMonitoredAction _action;

    public void TakePhone()
    {
        _action = eMonitoredAction.TakePhone;
        OnTriggeredByPlayer(_action);
        _simulation.OnTriggerScore(_action);
    }
    public void Appel()
    {
        _action = eMonitoredAction.Appel;
        OnTriggeredByPlayer(_action);
        _simulation.OnTriggerScore(_action);
    }
}
