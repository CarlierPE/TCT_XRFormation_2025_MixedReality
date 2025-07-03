using UnityEngine;
using UnityEngine.Events;

/*
 * Ce script est l� pour �ventuellement g�rer "l'apr�s tutorial" 
 * et avant que quoi que ce soit concernant la simulation n'ait lieu
 * On arrive ici uniquement quand on est s�rs et certains que le tuto est FINI et qu'on n'a plus besoin
 * d'aucun script/gameobject/etc du tuto. On setactive(false) tout ce qui concerne le tuto ici.
 * Ce script doit indiquer qu'il a termin� via son unity event
 * */
public class AfterTutorial : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnTutorialEnded;
    private void OnEnable()
    {
        OnTutorialEnded?.Invoke();
    }
}
