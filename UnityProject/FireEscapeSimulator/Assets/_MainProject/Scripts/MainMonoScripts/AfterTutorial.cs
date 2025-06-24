using UnityEngine;
using UnityEngine.Events;

/*
 * Ce script est là pour éventuellement gérer "l'après tutorial" 
 * et avant que quoi que ce soit concernant la simulation n'ait lieu
 * Il est possible que ce script n'ait rien à faire, mais il doit cependant avoir un UnityEvent 
 * pour indiquer qu'il s'est terminé
 * */
public class AfterTutorial : MonoBehaviour
{
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
