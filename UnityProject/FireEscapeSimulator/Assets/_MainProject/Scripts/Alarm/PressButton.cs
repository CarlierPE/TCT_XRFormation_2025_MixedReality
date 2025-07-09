using System.Collections.Generic;
using UnityEngine;

namespace TcT.FireSim
{
    public class PressButton : MonoBehaviour
    {
        public List<AudioSource> _audio;

        public void OnPress()
        {
            foreach (var item in _audio)
            {
                item.Play();
            }
        }

        public void StartSound()
        {
            if (_audio == null)
            {
                return;
            }

            foreach (var item in _audio)
            {
                item.Play();
            }
        }
    }
}