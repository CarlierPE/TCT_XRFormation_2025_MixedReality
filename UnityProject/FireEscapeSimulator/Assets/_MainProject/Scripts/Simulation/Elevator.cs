using UnityEngine;

namespace TcT.FireSim
{
    public class Elevator : TriggerableByPlayer
    {

        private void OnTriggerEnter(Collider other)
        {
            OnTriggeredByPlayer(eMonitoredAction.TouchElevator);
        }
    }
}