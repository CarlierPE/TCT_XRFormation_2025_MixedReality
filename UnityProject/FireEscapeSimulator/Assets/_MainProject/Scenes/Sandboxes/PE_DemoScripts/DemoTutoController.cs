using UnityEngine;

public class DemoTutoController : MonoBehaviour
{
    [SerializeField] Tutorial _tutorialScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _tutorialScript.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _tutorialScript.OnTutorialValidated.AddListener(TutorialIsOver);
    }

    private void OnDisable()
    {
        _tutorialScript.OnTutorialValidated.RemoveListener(TutorialIsOver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TutorialIsOver()
    {
        Debug.Log("Tutorial Has Been Completed");
        _tutorialScript.gameObject.SetActive(false);
    }
}
