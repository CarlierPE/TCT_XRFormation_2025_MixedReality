using UnityEngine;

public class Stairs : TriggerableByPlayer
{

    private readonly SimulationSript _simulation;
    private eMonitoredAction _action;
    public void UpStair()
    {
        _action = eMonitoredAction.StairsUp;
        OnTriggeredByPlayer(_action);
        _simulation.OnTriggerScore(_action);
    }
    public void DownStair()
    {
        _action = eMonitoredAction.FinishLine;
        OnTriggeredByPlayer(_action);
        _simulation.OnTriggerScore(_action);
    }
}
