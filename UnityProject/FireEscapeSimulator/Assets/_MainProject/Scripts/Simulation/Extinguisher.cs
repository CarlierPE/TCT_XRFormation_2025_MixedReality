using UnityEngine;

public class Extinguisher : TriggerableByPlayer
{
    private readonly SimulationSript _simulation;
    private eMonitoredAction _action;
    public void TrapExtinguisher()
    {
        _action = eMonitoredAction.ExtinguisherTake;
        OnTriggeredByPlayer(_action);
        _simulation.OnTriggerScore(_action);
    }

    public void PutOutTheFire()
    {
        _action = eMonitoredAction.ExtinguisherPutOut;
        OnTriggeredByPlayer(_action);
        _simulation.OnTriggerScore(_action);
    }

}
