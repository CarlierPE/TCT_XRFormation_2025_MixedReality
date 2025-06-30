using Meta.WitAi;
using UnityEngine;

public class AlarmBox : TriggerableByPlayer
{
    private readonly EmergencyLamp _lamp = new ();
    [SerializeField] GameObject _prefab;
    private readonly SimulationSript _simulation;
    public void OpenAlarmBox()
    {
        eMonitoredAction action = eMonitoredAction.OpenAlarmBox;
        // Logic to open the alarm box

        OnTriggeredByPlayer(action);
        _simulation.OnTriggerScore(action);
        // You can add more functionality here, such as changing visuals or state
    }

    public void PressButtonAlarmBox()
    { 
        eMonitoredAction action = eMonitoredAction.PressAlarmButton;
        // Logic to press the button on the alarm box
        OnTriggeredByPlayer(action);
        // You can add more functionality here, such as triggering an event or sound
        
        _prefab.SetActive(false);
        _lamp.RecivedSignal(action);
        _simulation.OnTriggerScore(action);
    }

    public void OnTriggeredPlayer(eMonitoredAction action)
    {
        // This method can be used to handle actions triggered by the player
        // For example, you can log the action or trigger other events

        _simulation.OnTriggerScore(action);
        _lamp.RecivedSignal(action);
    }

}
