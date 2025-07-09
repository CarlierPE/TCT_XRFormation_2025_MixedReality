using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

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

    [Header("Boutons")]
    public GameObject buttonToShow; // Bouton de fin
    public Button manualNextButton; // Bouton manuel pour passer au slide suivant
    public GameObject manualNextButton0;

    private int currentIndex = 0;
    private Coroutine autoNextCoroutine;

    void Start()
    {
        if (buttonToShow != null)
            buttonToShow.SetActive(false);
        if (manualNextButton != null)
            manualNextButton0.SetActive(false);

        ShowCurrent();

        if (autoPlay)
            autoNextCoroutine = StartCoroutine(AutoNextCoroutine());

        // On connecte le bouton manuel s’il est assigné
        if (manualNextButton != null)
            manualNextButton.onClick.AddListener(ManualNext);
        // ✅ Lancer la coroutine d'affichage du bouton manuel après 2 secondes
        StartCoroutine(ShowManualButtonAfterDelay());
    }

    [ContextMenu("Next")]
    public void ManualNext()
    {
        if (currentIndex < textContents.Count - 1)
        {
            currentIndex++;
            ShowCurrent();

            // Redémarrer la coroutine (remettre le timer à zéro)
            if (autoNextCoroutine != null)
                StopCoroutine(autoNextCoroutine);

            autoNextCoroutine = StartCoroutine(AutoNextCoroutine());
        }
        else
        {
            // Fin de la liste : on affiche le bouton final
            if (autoNextCoroutine != null)
                StopCoroutine(autoNextCoroutine);

            if (buttonToShow != null)
                buttonToShow.SetActive(true);
            if (manualNextButton0 != null)
                manualNextButton0.SetActive(false);
        }
    }

    void ShowCurrent()
    {
        if (currentIndex < textContents.Count)
        {
            Debug.Log("Texte à afficher : " + textContents[currentIndex]);
            displayText.text = textContents[currentIndex];
            displayText.ForceMeshUpdate();
        }
    }

    private IEnumerator AutoNextCoroutine()
    {
        yield return new WaitForSeconds(changeInterval);

        if (currentIndex < textContents.Count - 1)
        {
            currentIndex++;
            ShowCurrent();

            autoNextCoroutine = StartCoroutine(AutoNextCoroutine());
        }
        else
        {
            if (buttonToShow != null)
                buttonToShow.SetActive(true);
        }
    }

    private IEnumerator ShowManualButtonAfterDelay()
        {
            yield return new WaitForSeconds(2f); // délai en secondes

            if (manualNextButton0 != null)
                manualNextButton0.SetActive(true);
         
        }

    }

