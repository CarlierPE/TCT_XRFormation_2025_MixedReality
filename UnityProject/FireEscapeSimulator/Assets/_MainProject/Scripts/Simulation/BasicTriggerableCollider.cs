using UnityEngine;

namespace TcT.FireSim
{
    [RequireComponent(typeof(Collider))]
    public class BasicTriggerableCollider : TriggerableByPlayer
    {
        [SerializeField] eMonitoredAction _actionType;

        private void OnTriggerEnter(Collider other)
        {
            OnTriggeredByPlayer(_actionType);
        }
    }
}