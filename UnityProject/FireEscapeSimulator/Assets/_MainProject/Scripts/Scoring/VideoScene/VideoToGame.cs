using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoToGame : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string sceneToLoad = "MainScene"; // nom de la scène du jeu

    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
    }

    void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}