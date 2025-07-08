using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] List<Door> _doors;

    public void ResetDoors()
    {
        _doors.ForEach(d => d.Reset());
    }
}
