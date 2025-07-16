using TcT.FireSim;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoToGame : MonoBehaviour
{
    public MainGameScript mainGameScript;
    public VideoPlayer videoPlayer;
   [SerializeField] string sceneToLoad = "MainScene"; // nom de la scène du jeu

    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
    }

    void EndReached(VideoPlayer vp)
    {
        
      
    }
}