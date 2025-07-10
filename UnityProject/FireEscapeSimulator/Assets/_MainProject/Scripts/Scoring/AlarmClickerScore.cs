using UnityEngine;

namespace TcT.FireSim
{
    public class AlarmClickerScore : TriggerableByPlayer
    {
        public AlarmClickerScore TheScore;


        void OnTriggerEnter(Collider other)
        {
            OnTriggeredByPlayer(eMonitoredAction.PressAlarmButton);
        }
    }
}