using UnityEngine;

public class Extinguisher : TriggerableByPlayer
{
    public void TrapExtinguisher()
    {
        OnTriggeredByPlayer(eMonitoredAction.Extinguisher);
    }

    public void PutOutTheFire()
    {
        OnTriggeredByPlayer(eMonitoredAction.ExtinguisherPutOut);
    }

}
