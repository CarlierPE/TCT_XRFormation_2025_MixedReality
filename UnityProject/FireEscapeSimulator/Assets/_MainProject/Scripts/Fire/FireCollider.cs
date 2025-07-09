using UnityEngine;

public class FireCollider : TriggerableByPlayer
{
    //we only collide with the Player layer
    private void OnTriggerEnter(Collider other)
    {
        OnTriggeredByPlayer(eMonitoredAction.WalkIntoFire);
    }
}
