using TcT.FireSim;
using UnityEngine;

public class InteractionPressButton : MonoBehaviour
{
    [SerializeField] private  StartAlarmBox  _alarms;

    private bool _triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_triggered) return;

        _alarms.StartSound();

        _triggered = true;
    }
}
