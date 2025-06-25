using UnityEngine;
using UnityEngine.Events;

public abstract class TutorialStep : MonoBehaviour
{
    // Un identifiant pour savoir quelle étape est en cours
    public abstract string ID { get; }

    // Appelé pour démarrer l’étape
    public abstract void StartStep();

    // Événement à déclencher quand l’étape est finie
    public UnityEvent OnStepCompleted;

    // Optionnel : pour que d’autres scripts puissent forcer la fin
    public virtual void CompleteStep()
    {
        Debug.Log($"Etape {ID} terminée !");
        OnStepCompleted?.Invoke();
    }
}