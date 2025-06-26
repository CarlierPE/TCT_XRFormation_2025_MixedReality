using UnityEngine;
using UnityEngine.Events;

public abstract class TutorialStep : MonoBehaviour
{
    // Appelé pour démarrer l’étape
    public abstract void StartStep();

    // Événement à déclencher quand l’étape est finie
    //le bool indique true si la step est un "succès" false si la step est un "échec"
    //ce qui veut dire qu'il faut recommencer le tuto
    [HideInInspector]
    public UnityEvent<bool> OnStepCompleted;
}