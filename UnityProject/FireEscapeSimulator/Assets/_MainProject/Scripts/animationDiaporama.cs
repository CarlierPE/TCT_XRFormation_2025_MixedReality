using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class ImageWithTextMultiLanguage
{
    public Texture2D texture;
    public string m_idTextMultiLanguage;
    public string m_defaultTextForDebug;
}

public class animationDiaporama : MonoBehaviour
{
    [Header("Images UI")]
    public RawImage displayImage;                 // L'image dans l'UI
    public RectTransform imageContainer;          // Le RectTransform du RawImage
    public RectTransform buttonRect;              // Pour adapter la taille du bouton
    public List<Texture2D> texturePaths;             // Chemins vers les images dans Resources/

    [Header("Objets à activer/désactiver")]
    public List<GameObject> objectsToCycle;       // Liste des GameObjects à afficher un par un

    private int currentIndex = 0;

    void Start()
    {
        ShowCurrent();
    }
    [ContextMenu("Next")]
    public void Next()
    {
        currentIndex = (currentIndex + 1) % Mathf.Max(texturePaths.Count, objectsToCycle.Count);
        ShowCurrent();
    }

    void ShowCurrent()
    {
        // === 1. Affichage de l'image ===
        if (texturePaths.Count > 0 && currentIndex < texturePaths.Count)
        {
            
            Texture2D tex = texturePaths[currentIndex];

            if (tex != null)
            {
                displayImage.texture = tex;

                float imageWidth = tex.width;
                float imageHeight = tex.height;
                float ratio = imageWidth / imageHeight;

                float baseHeight = 500f;
                float width = baseHeight * ratio;

                Vector2 newSize = new Vector2(width, baseHeight);

                imageContainer.sizeDelta = newSize;
                if (buttonRect != null)
                    buttonRect.sizeDelta = newSize;
            }
            else
            {
                Debug.LogWarning("Image non trouvée : " + texturePaths[currentIndex]);
            }
        }

        // === 2. Activation d'un seul GameObject ===
        for (int i = 0; i < objectsToCycle.Count; i++)
        {
            objectsToCycle[i].SetActive(i == currentIndex);
        }
    }
}

//void Update()
//{
    //if 
//}