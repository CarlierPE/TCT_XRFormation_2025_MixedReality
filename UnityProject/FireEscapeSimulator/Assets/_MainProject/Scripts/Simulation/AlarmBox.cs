using TcT.FireSim;
using UnityEngine;

public class AlarmBox : TriggerableByPlayer
{
    private void OnTriggerEnter(Collider other)
    {
        OnTriggeredByPlayer(eMonitoredAction.PressAlarmButton);
    }

}
