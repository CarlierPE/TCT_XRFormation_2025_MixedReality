using UnityEngine;
using UnityEngine.Events;

public abstract class TutorialStep : MonoBehaviour
{
    // Appelé pour démarrer l’étape
    public abstract void StartStep();

    // Événement à déclencher quand l’étape est finie
    public UnityEvent OnStepCompleted;
}