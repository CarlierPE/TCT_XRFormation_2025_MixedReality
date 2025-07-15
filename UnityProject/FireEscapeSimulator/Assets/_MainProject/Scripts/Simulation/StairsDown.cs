using UnityEngine;

namespace TcT.FireSim
{
    public class StairsDown : TriggerableByPlayer
    {
        private void OnTriggerEnter(Collider other)
        {
            OnTriggeredByPlayer(eMonitoredAction.FinishLine);
        }
    }
}