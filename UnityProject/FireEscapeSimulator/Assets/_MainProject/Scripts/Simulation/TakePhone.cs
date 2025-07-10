using UnityEngine;

namespace TcT.FireSim
{
    public class TakePhone : TriggerableByPlayer
    {
        private void OnTriggerEnter(Collider other)
        {
            OnTriggeredByPlayer(eMonitoredAction.TakePhone);
        }
    }
}