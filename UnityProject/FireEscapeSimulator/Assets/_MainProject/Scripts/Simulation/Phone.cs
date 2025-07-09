using UnityEngine;

namespace TcT.FireSim
{
    public class Phone : TriggerableByPlayer
    {
        private void OnTriggerEnter(Collider other)
        {
            OnTriggeredByPlayer(eMonitoredAction.Appel);
        }
    }
}