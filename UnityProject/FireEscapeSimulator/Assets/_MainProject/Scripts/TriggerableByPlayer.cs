using UnityEngine;
using UnityEngine.Events;

public abstract class TriggerableByPlayer : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent<eMonitoredAction> Triggered;

    protected void OnTriggeredByPlayer(eMonitoredAction action)
    {
        Triggered?.Invoke(action);
    }
}
