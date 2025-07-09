using UnityEngine;

namespace TcT.FireSim
{
    public class FireCollider : TriggerableByPlayer
    {
        public PlayerSound sound;
        //we only collide with the Player layer
        private void OnTriggerEnter(Collider other)
        {
            sound.OnWalkinginFire();
            OnTriggeredByPlayer(eMonitoredAction.WalkIntoFire);
        }
    }
}