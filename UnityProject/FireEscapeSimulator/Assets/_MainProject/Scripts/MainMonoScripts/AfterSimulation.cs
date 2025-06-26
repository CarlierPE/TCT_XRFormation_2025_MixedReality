using UnityEngine;
using UnityEngine.Events;
/*
 * Le but de ce script est le nettoyage éventuel de la scène post simulation
 * Probablement du setactive(false) etc sur tout un tas de choses (le feu déjà) histoire que le casque puisse se reposer
 * Besoin d'un UnityEvent pour signaler que l'étape est terminée.
 * */
public class AfterSimulation : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnSimulationEnded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
