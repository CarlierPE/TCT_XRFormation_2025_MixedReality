using UnityEngine;

namespace TcT.FireSim
{
    public class EmergencyExit : TriggerableByPlayer
    {
        private void OnTriggerEnter(Collider other)
        {
            OnTriggeredByPlayer(eMonitoredAction.FinishLine);
        }
    }
}