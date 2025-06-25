using UnityEngine;
using UnityEngine.Events;

public abstract class TutorialStep : MonoBehaviour
{
    // Appel� pour d�marrer l��tape
    public abstract void StartStep();

    // �v�nement � d�clencher quand l��tape est finie
    public UnityEvent OnStepCompleted;
}