using UnityEngine;

public class EmergencyLamp 
{

    [SerializeField] private GameObject lampLight;
    [SerializeField] private GameObject lampMesh;
    private bool isOn = false;
    private void ToggleLamp()
    {
        isOn = !isOn;
        lampLight.SetActive(isOn);
        lampMesh.SetActive(isOn);
    }

    public void RecivedSignal(eMonitoredAction action)
    {
        if (action == eMonitoredAction.PressAlarmButton)
        {
            ToggleLamp();
        }
    }
}
