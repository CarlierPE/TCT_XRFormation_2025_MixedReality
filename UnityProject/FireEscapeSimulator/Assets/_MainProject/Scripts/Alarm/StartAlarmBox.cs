using System.Collections.Generic;
using UnityEngine;

namespace TcT.FireSim
{
    public class StartAlarmBox : MonoBehaviour
    {
        public List<AudioSource> _alarm;

        public void StartSound()
        {
            
            foreach (AudioSource source in _alarm)
            {
                source.Play();
            }
        }

        public void StopSound()
        {
            
            foreach (AudioSource source in _alarm)
            {
                source.Stop();
            }
        }
    }
}