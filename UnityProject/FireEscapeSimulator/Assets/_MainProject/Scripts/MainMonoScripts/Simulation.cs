using UnityEngine;
using UnityEngine.Events;

/*
 * Script principal de la simulation
 * Devra g�rer tout ce qui tourne autour:
 * - d�clencher le d�part et expansion du feu/fum�e
 * - d�marrer le timer et le scoring
 * - indiquer au scoring les actions prises par l'utilisateur
 * - indiquer que la simulation est termin�e via un unityevent
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
