using UnityEngine;

public class StairsDown : TriggerableByPlayer
{
    private void OnTriggerEnter(Collider other)
    {
        OnTriggeredByPlayer(eMonitoredAction.FinishLine);
    }
}
