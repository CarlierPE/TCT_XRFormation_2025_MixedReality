using UnityEngine;
using UnityEngine.Events;

namespace TcT.FireSim
{
    public abstract class TriggerableByPlayer : MonoBehaviour
    {
        [HideInInspector]
        public UnityEvent<eMonitoredAction> Triggered;

        protected void OnTriggeredByPlayer(eMonitoredAction action)
        {
            Triggered?.Invoke(action);
        }
    }
}