using UnityEngine;
using UnityEngine.Events;
/*
 * Ce script doit pr�parer le terrain le script simulation
 * Encore � d�terminer
 * Doit d�clencher un UnityEvent � la fin de son travail
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
