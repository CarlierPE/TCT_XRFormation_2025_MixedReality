using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SlideshowWithImageList : MonoBehaviour
{
    public List<RawImage> imageList; // Assigne dans l’Inspector
    public float interval = 2f;
    public float fadeDuration = 0.5f;

    private int currentIndex = 0;

    void Start()
    {
        // Masquer toutes les images sauf la première
        for (int i = 0; i < imageList.Count; i++)
        {
            SetAlpha(imageList[i], i == 0 ? 1f : 0f);
        }

        if (imageList.Count > 1)
            StartCoroutine(PlaySlideshow());
    }

    IEnumerator PlaySlideshow()
    {
        while (true)
        {
            RawImage currentImage = imageList[currentIndex];
            int nextIndex = (currentIndex + 1) % imageList.Count;
            RawImage nextImage = imageList[nextIndex];

            // Fade out current
            yield return StartCoroutine(FadeImage(currentImage, 1f, 0f, fadeDuration));

            // Fade in next
            yield return StartCoroutine(FadeImage(nextImage, 0f, 1f, fadeDuration));

            currentIndex = nextIndex;

            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator FadeImage(RawImage img, float from, float to, float duration)
    {
        float elapsed = 0f;
        Color c = img.color;
        while (elapsed < duration)
        {
            c.a = Mathf.Lerp(from, to, elapsed / duration);
            img.color = c;
            elapsed += Time.deltaTime;
            yield return null;
        }
        c.a = to;
        img.color = c;
    }

    void SetAlpha(RawImage img, float alpha)
    {
        Color c = img.color;
        c.a = alpha;
        img.color = c;
    }
}
