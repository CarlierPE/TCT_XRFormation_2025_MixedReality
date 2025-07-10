using UnityEngine;

namespace TcT.FireSim
{
    public class Victory : TriggerableByPlayer
    {
        public ScoreManager TheEndingShower;

        void OnTriggerEnter(Collider other)
        {
            OnTriggeredByPlayer(eMonitoredAction.FinishLine);
        }

    }
}