using UnityEngine;

public class Door : TriggerableByPlayer
{
    [SerializeField] private GameObject _door;
    
    private void OnTriggerEnter(Collider other)
    {
        _door.SetActive(true);
        OnTriggeredByPlayer(eMonitoredAction.CloseDoor);
    }
}
