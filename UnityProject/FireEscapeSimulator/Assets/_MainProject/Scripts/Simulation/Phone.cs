using UnityEngine;

public class Phone : TriggerableByPlayer
{
    public void TakePhone()
    {
        OnTriggeredByPlayer(eMonitoredAction.TakePhone);
    }
    public void Appel()
    {
        OnTriggeredByPlayer(eMonitoredAction.Appel);
    }
}
