using UnityEngine;
using UnityEngine.Events;

/*
 * Script principal de la simulation
 * Devra gérer tout ce qui tourne autour:
 * - déclencher le départ et expansion du feu/fumée
 * - démarrer le timer et le scoring
 * - indiquer au scoring les actions prises par l'utilisateur
 * - indiquer que la simulation est terminée via un unityevent
 * */
public class Simulation : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnSimulationEnding;

    private void OnEnable()
    {
        //TODO - tout
        OnSimulationEnding.Invoke();
    }
}
