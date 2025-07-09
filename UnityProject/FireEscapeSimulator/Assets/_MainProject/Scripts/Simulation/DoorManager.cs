using System.Collections.Generic;
using UnityEngine;

namespace TcT.FireSim
{
    public class DoorManager : MonoBehaviour
    {
        [SerializeField] List<Door> _doors;

        public void ResetDoors()
        {
            _doors.ForEach(d => d.Reset());
        }
    }
}