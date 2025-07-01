using UnityEngine;
using UnityEngine.Events;

/*
 * Ce script est là pour éventuellement gérer "l'après tutorial" 
 * et avant que quoi que ce soit concernant la simulation n'ait lieu
 * On arrive ici uniquement quand on est sûrs et certains que le tuto est FINI et qu'on n'a plus besoin
 * d'aucun script/gameobject/etc du tuto. On setactive(false) tout ce qui concerne le tuto ici.
 * Ce script doit indiquer qu'il a terminé via son unity event
 * */
public class AfterTutorial : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnTutorialEnded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
