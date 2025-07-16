using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneCinematicMono : MonoBehaviour
{
    public float m_secondsBeforeLoadingNextScene = 5;

    void OnEnable()
    {
        Invoke("LoadScene", m_secondsBeforeLoadingNextScene);
    }

    public void LoadScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        // Optionnel : vérifier si l'index suivant existe
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.LogWarning("No next scene found. You are at the last scene in Build Settings.");
        }
    }
}