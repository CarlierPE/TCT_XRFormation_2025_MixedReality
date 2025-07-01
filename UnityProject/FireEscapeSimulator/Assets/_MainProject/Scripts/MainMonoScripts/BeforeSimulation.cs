using UnityEngine;
using UnityEngine.Events;
/*
 * Ce script doit préparer le terrain le script simulation
 * Encore à déterminer
 * Doit déclencher un UnityEvent à la fin de son travail
 * */
public class BeforeSimulation : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnSimulationStarting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
