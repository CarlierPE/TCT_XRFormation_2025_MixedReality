using UnityEngine;

namespace TcT.FireSim
{
    public class DoorClose : TriggerableByPlayer
    {
        private void OnTriggerEnter(Collider other)
        {
            OnTriggeredByPlayer(eMonitoredAction.CloseDoor);
        }
    }
}