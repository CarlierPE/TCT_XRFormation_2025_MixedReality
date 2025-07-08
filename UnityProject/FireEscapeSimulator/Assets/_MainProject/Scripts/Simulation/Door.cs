using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Door : TriggerableByPlayer
{
    [SerializeField] private GameObject _door;
    private bool _triggered = false;
    private MeshRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(_triggered) return;

        _door.SetActive(true);
        OnTriggeredByPlayer(eMonitoredAction.CloseDoor);
        _triggered = true;
        _renderer.enabled = false;
    }

    public void Reset()
    {
        _door.SetActive(false);
        _triggered = false;
        _renderer.enabled = true;
    }
}
