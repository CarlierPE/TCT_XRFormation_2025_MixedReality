using System.Collections.Generic;
using UnityEngine;

public class DiaporamaGameObject : MonoBehaviour
{
    public List<GameObject> objectsToCycle;
    private int currentIndex = 0;

    void Start()
    {
        UpdateObjects();
    }

    public void NextObject()
    {
        currentIndex = (currentIndex + 1) % objectsToCycle.Count;
        UpdateObjects();
    }

    void UpdateObjects()
    {
        for (int i = 0; i < objectsToCycle.Count; i++)
        {
            objectsToCycle[i].SetActive(i == currentIndex);
        }
    }
}