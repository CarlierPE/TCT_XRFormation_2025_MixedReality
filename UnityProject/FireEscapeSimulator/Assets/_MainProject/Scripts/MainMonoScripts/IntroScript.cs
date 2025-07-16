using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

namespace TcT.FireSim
{
    public class IntroScript : MonoBehaviour
    {
        [SerializeField] GameObject _ui;
        [HideInInspector]
        public UnityEvent OnIntroFinished;
        
        [SerializeField] VideoPlayer _videoPlayer;

        void EndReached(VideoPlayer vp)
        {
        
            OnIntroFinished.Invoke();
        }
        private void OnEnable()
        {
            _ui.SetActive(true);
            _videoPlayer.loopPointReached += EndReached;
            _videoPlayer.Play();
        }

        private void OnDisable()
        {
            _videoPlayer.loopPointReached -= EndReached;
            _ui.SetActive(false);
        }
    }
}