using UnityEngine;

public class Extinguisher : TriggerableByPlayer
{
    public void TrapExtinguisher()
    {
        OnTriggeredByPlayer(eMonitoredAction.ExtinguisherTake);
    }

    public void PutOutTheFire()
    {
        OnTriggeredByPlayer(eMonitoredAction.ExtinguisherPutOut);
    }

}
