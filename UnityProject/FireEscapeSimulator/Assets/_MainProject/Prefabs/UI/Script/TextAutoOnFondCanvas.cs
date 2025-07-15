using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class textUpdateOnCanvas : MonoBehaviour
{
    [Header("GifMaker")] public bool autoPlay = true;
    public float changeInterval = 3f;

    [Header("Texte UI")] public TextMeshProUGUI displayText;
    public Canvas canvas;
    public List<string> textContents;

    [Header("Boutons")] public GameObject buttonToShow; // Bouton final
    public Button manualNextButton; // Bouton manuel
    //public GameObject manualNextButton0; // GameObject contenant le bouton

    private int currentIndex = 0;
    

    void OnEnable()
    {
        currentIndex = 0;
        if (buttonToShow != null)
            buttonToShow.SetActive(false);

        if (manualNextButton != null)
            manualNextButton.gameObject.SetActive(true);

        ShowCurrent();
        
        if (manualNextButton != null)
            manualNextButton.onClick.AddListener(ManualNext);


    }

    private void OnDisable()
    {
        if (buttonToShow != null)
            buttonToShow.SetActive(true);

        if (manualNextButton != null)
            manualNextButton.gameObject.SetActive(false);
        
        if (manualNextButton != null)
            manualNextButton.onClick.RemoveListener(ManualNext);
    }

    [ContextMenu("Next")]
    public void ManualNext()
    {
        Next();
    }

    void AutoNext()
    {
        Next();
    }

    void Next()
    {
        currentIndex++;
        ShowCurrent();
        
    }

    void ShowCurrent()
    {
        if (currentIndex < textContents.Count)
        {
            Debug.Log("Texte à afficher : " + textContents[currentIndex]);
            displayText.text = textContents[currentIndex];
            //displayText.ForceMeshUpdate();

            // Réactiver le bouton manuel à chaque texte (utile si on recommence)
            //Invoke(nameof(ShowManualButton), 0.5f);
        }
        if (currentIndex == textContents.Count - 1)
        {
            if (manualNextButton != null)
                manualNextButton.gameObject.SetActive(false);

            if (buttonToShow != null)
                buttonToShow.SetActive(true);
        }
    }
}
