using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class textUpdateOnCanvas : MonoBehaviour
{
    
    
    

    [Header("Objets à activer/désactiver")]
    public List<GameObject> objectsToCycle;       // GameObjects à activer/désactiver

    [Header("Texte UI")]
    public TextMeshProUGUI displayText;           // Texte à afficher
    public Canvas canvas;
    public List<string> textContents;             // Contenu textuel pour chaque slide

    private int currentIndex = 0;

    void Start()
    {
        ShowCurrent();
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
        displayText.ForceMeshUpdate(); // Pour forcer le calcul du layout
    }

        
}
