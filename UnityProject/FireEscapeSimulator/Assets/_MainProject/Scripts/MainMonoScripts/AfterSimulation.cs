using UnityEngine;
using UnityEngine.Events;
/*
 * Le but de ce script est le nettoyage �ventuel de la sc�ne post simulation
 * Probablement du setactive(false) etc sur tout un tas de choses (le feu d�j�) histoire que le casque puisse se reposer
 * Besoin d'un UnityEvent pour signaler que l'�tape est termin�e.
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
