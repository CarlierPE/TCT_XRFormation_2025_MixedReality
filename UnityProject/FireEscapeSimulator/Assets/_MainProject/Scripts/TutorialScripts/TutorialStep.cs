using UnityEngine;
using UnityEngine.Events;

public abstract class TutorialStep : MonoBehaviour
{
    // Appel� pour d�marrer l��tape
    public abstract void StartStep();

    // �v�nement � d�clencher quand l��tape est finie
    //le bool indique true si la step est un "succ�s" false si la step est un "�chec"
    //ce qui veut dire qu'il faut recommencer le tuto
    [HideInInspector]
    public UnityEvent<bool> OnStepCompleted;
}