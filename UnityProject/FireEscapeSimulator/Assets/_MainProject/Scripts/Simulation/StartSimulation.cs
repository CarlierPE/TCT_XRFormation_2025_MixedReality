using UnityEngine;

namespace TcT.FireSim
{
    public class StartSimulation : TriggerableByPlayer
    {
        private void OnTriggerEnter(Collider other)
        {
            OnTriggeredByPlayer(eMonitoredAction.EnterKitchen);
        }
    }
}