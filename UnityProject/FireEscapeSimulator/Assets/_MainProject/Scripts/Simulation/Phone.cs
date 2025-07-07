using UnityEngine;

public class Phone : TriggerableByPlayer
{
    private void OnTriggerEnter(Collider other)
    {
        OnTriggeredByPlayer(eMonitoredAction.Appel);
    }
}
