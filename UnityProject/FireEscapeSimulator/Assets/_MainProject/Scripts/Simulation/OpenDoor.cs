using UnityEngine;

namespace TcT.FireSim
{
    public class OpenDoor : TriggerableByPlayer
    {
        private void OnTriggerEnter(Collider other)
        {
            OnTriggeredByPlayer(eMonitoredAction.OpenDoor);
        }
    }
}