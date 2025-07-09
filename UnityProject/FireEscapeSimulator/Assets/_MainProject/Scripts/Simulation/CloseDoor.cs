using UnityEngine;

namespace TcT.FireSim
{
    public class CloseDoor : MonoBehaviour
    {
        [SerializeField] private GameObject[] _doors;

        private void Awake()
        {
            foreach (var door in _doors)
            {
                door.SetActive(false);
            }
        }

    }
}