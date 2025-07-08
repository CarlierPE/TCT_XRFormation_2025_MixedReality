using UnityEngine;

public class TakePhone : TriggerableByPlayer
{
    private void OnTriggerEnter(Collider other)
    {
        OnTriggeredByPlayer(eMonitoredAction.TakePhone);
    }
}
