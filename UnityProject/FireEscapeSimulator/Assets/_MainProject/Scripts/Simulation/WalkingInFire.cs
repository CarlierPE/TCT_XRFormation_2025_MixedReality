using UnityEngine;

public class WalkingInFire : TriggerableByPlayer
{
    private void OnTriggerEnter(Collider other)
    {
        OnTriggeredByPlayer(eMonitoredAction.WalkIntoFire);
    }
}