using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using PrimeTween;

public class SlideshowWithPrimeTween : MonoBehaviour
{
    public RawImage displayImage;
    public CanvasGroup canvasGroup; // Assign the CanvasGroup of the wrapper
    public string imagesFolder = "Images";
    public float interval = 2f;
    public float transitionDuration = 0.5f;

    private List<Texture2D> textures = new List<Texture2D>();
    private int currentIndex = 0;

    void Start()
    {
        LoadImages();
        ShowNextImage();
    }

    void LoadImages()
    {
        Object[] loadedImages = Resources.LoadAll(imagesFolder, typeof(Texture2D));
        foreach (Object img in loadedImages)
        {
            textures.Add((Texture2D)img);
        }
    }

    void ShowNextImage()
    {
        if (textures.Count == 0) return;

        // Fade out
        Tween.(canvasGroup, 1f, 0f, transitionDuration)
            .OnComplete(() =>
            {
                // Change image
                displayImage.texture = textures[currentIndex];
                currentIndex = (currentIndex + 1) % textures.Count;

                // Fade in
                Tween.(canvasGroup, 0f, 1f, transitionDuration)
                    .OnComplete(() =>
                    {
                        Tween.Delay(interval).OnComplete(() => ShowNextImage());
                    });
            });
    }
}