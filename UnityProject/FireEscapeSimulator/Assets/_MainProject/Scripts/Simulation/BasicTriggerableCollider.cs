using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BasicTriggerableCollider : TriggerableByPlayer
{
    [SerializeField] eMonitoredAction _actionType;

    private void OnTriggerEnter(Collider other)
    {
        base.OnTriggeredByPlayer(_actionType);
    }
}
