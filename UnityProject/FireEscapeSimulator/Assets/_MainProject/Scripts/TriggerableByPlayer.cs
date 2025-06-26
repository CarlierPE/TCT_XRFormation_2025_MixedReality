using UnityEngine;
using UnityEngine.Events;

public abstract class TriggerableByPlayer : MonoBehaviour
{
    [SerializeField] UnityEvent<eMonitoredAction> Triggered;

    protected void OnTriggeredByPlayer(eMonitoredAction action)
    {
        Triggered?.Invoke(action);
    }
}
