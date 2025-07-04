using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI; // pour le bouton

public class textUpdateOnCanvas : MonoBehaviour
{
    [Header("GifMaker")]
    public bool autoPlay = true;
    public float changeInterval = 3f;

    [Header("Objets à activer/désactiver")]
    public List<GameObject> objectsToCycle;

    [Header("Texte UI")]
    public TextMeshProUGUI displayText;
    public Canvas canvas;
    public List<string> textContents;

    [Header("Bouton à afficher après 2 cycles")]
    public GameObject buttonToShow;

    private int currentIndex = 0;
    private int autoNextCount = 0; // compteur de fois où AutoNext est appelé

    void Start()
    {
        if (buttonToShow != null)
            buttonToShow.SetActive(false); // on cache le bouton au départ

        ShowCurrent();
        if (autoPlay)
            StartCoroutine(AutoNextCoroutine());
    }

    [ContextMenu("Next")]
    public void Next()
    {
        int maxCount = Mathf.Max(textContents.Count, objectsToCycle.Count);
        currentIndex = (currentIndex + 1) % maxCount;
        ShowCurrent();
        displayText.SetAllDirty();
    }

    void ShowCurrent()
    {
        Debug.Log("Texte à afficher : " + textContents[currentIndex]);
        displayText.text = textContents[currentIndex];
        displayText.ForceMeshUpdate();
    }

    private IEnumerator AutoNextCoroutine()
    {
        while (autoNextCount < 1)
        {
            yield return new WaitForSeconds(changeInterval);
            Next();
            autoNextCount++;
        }

        
        if (buttonToShow != null)
            buttonToShow.SetActive(true);
    }
}