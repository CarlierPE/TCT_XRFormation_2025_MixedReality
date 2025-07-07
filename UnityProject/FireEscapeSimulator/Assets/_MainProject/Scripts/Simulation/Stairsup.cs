using UnityEngine;

public class StairsUp : TriggerableByPlayer
{
    private void OnTriggerEnter(Collider other)
    {
        OnTriggeredByPlayer(eMonitoredAction.StairsUp);
    }
}
