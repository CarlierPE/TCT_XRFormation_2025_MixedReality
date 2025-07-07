using UnityEngine;

public class DoorClosing : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    public void CloseDoorSelect()
    {
        _door.SetActive(true);
    }
}
