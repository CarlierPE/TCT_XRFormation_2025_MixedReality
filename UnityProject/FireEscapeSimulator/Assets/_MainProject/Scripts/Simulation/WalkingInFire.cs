using UnityEngine;

namespace TcT.FireSim
{
    public class WalkingInFire : TriggerableByPlayer
    {
        private void OnTriggerEnter(Collider other)
        {
            OnTriggeredByPlayer(eMonitoredAction.WalkIntoFire);
        }
    }
}