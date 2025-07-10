using UnityEngine;
using UnityEngine.Video;

public class StartVideoOnLaunch : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.Play();
    }
}