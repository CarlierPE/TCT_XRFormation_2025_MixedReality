using UnityEngine;
using UnityEngine.Events;

public abstract class TutorialStep : MonoBehaviour
{
    // Un identifiant pour savoir quelle �tape est en cours
    public abstract string ID { get; }

    // Appel� pour d�marrer l��tape
    public abstract void StartStep();

    // �v�nement � d�clencher quand l��tape est finie
    public UnityEvent OnStepCompleted;

    // Optionnel : pour que d�autres scripts puissent forcer la fin
    public virtual void CompleteStep()
    {
        Debug.Log($"Etape {ID} termin�e !");
        OnStepCompleted?.Invoke();
    }
}