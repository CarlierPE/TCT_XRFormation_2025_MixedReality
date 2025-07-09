using UnityEngine;

namespace TcT.FireSim
{
    public class FireCollider : TriggerableByPlayer
    {
        public AudioSource onFire;

        //we only collide with the Player layer
        private void OnTriggerEnter(Collider other)
        {
            onFire.Play();
            OnTriggeredByPlayer(eMonitoredAction.WalkIntoFire);
        }
    }
}