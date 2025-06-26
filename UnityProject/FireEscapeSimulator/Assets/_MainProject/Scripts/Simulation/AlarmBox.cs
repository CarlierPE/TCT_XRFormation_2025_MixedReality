using Meta.WitAi;
using UnityEngine;

public class AlarmBox : TriggerableByPlayer
{
    public void OpenAlarmBox()
    {
        // Logic to open the alarm box
        OnTriggeredByPlayer(eMonitoredAction.OpenAlarmBox);
        // You can add more functionality here, such as changing visuals or state
    }

    public void PressButtonAlarmBox()
    {
        // Logic to press the button on the alarm box
        OnTriggeredByPlayer(eMonitoredAction.PressAlarmButton);
        // You can add more functionality here, such as triggering an event or sound
        GameObject prefab = GetComponent<GameObject>();
        prefab.SetActive(false);
    }

}
