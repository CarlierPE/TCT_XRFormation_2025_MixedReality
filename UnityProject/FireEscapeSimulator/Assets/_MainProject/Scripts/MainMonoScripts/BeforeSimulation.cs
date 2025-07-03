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

    private void OnEnable()
    {
        //ENORME TODO ici
        OnSimulationStarting.Invoke();
    }
}
