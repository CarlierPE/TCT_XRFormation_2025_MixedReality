using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animationDiaporama : MonoBehaviour
{
    [Header("GifMaker")]
    public bool autoPlay = true;
    public float changeInterval = 3f;

    [Header("Images UI")]
    public RawImage displayImage;               // RawImage où afficher la texture
    public RectTransform imageContainer;        // RectTransform à redimensionner selon l’image
    public RectTransform maxContainerSize;      // Zone limite optionnelle
    public List<Texture2D> texturePaths;        // Liste des textures à afficher

    [Header("Objets à activer/désactiver")]
    public List<GameObject> objectsToCycle;     // Objets à afficher un par un

    private int currentIndex = 0;

    void Start()
    {
        ShowCurrent();
        if (autoPlay)
            StartCoroutine(AutoNextCoroutine());
    }

    [ContextMenu("Next")]
    public void Next()
    {
        //int maxCount = Mathf.Max(texturePaths.Count, objectsToCycle.Count);
        //if (maxCount == 0) return;

        int nextIndex = currentIndex + 1;

        if (nextIndex >= texturePaths.Count)
        {
            currentIndex = 0;
            
        }
        else
        {
            currentIndex = nextIndex;
        }

        ShowCurrent();
    }

    void ShowCurrent()
    {
        if (texturePaths.Count == 0)
        {
            Debug.LogWarning("Pas d'images dans texturePaths !");
            return;
        }

        if (currentIndex >= texturePaths.Count)
        {
            Debug.LogWarning("Index hors limite !");
            return;
        }

        Texture2D tex = texturePaths[currentIndex];

        if (tex == null)
        {
            Debug.LogWarning("Texture null à l'index " + currentIndex);
            return;
        }

        // Limites d'affichage
        float maxWidth = maxContainerSize != null ? maxContainerSize.rect.width : imageContainer.rect.width;
        float maxHeight = maxContainerSize != null ? maxContainerSize.rect.height : imageContainer.rect.height;

        float origWidth = tex.width;
        float origHeight = tex.height;

        float widthRatio = maxWidth / origWidth;
        float heightRatio = maxHeight / origHeight;
        float scaleFactor = Mathf.Min(widthRatio, heightRatio);

        float finalWidth = origWidth * scaleFactor;
        float finalHeight = origHeight * scaleFactor;

        imageContainer.sizeDelta = new Vector2(finalWidth, finalHeight);

        displayImage.texture = tex;
    }

    private IEnumerator AutoNextCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeInterval);
            //
            Next();
            
           
        }
    }


    void OnReachedEnd()
    {
       
    }
}
