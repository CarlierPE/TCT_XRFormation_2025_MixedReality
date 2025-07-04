using UnityEngine;
using UnityEngine.Events;

public abstract class TutorialStep : MonoBehaviour
{
    // Appel� pour d�marrer l��tape
    protected abstract void DoStep();
    private bool _canStart;

    private void Update()
    {
        if (!_canStart) return;
        _canStart = false;
        DoStep();
    }
    public void StartStep()
    {
        _canStart = true;
    }
    // �v�nement � d�clencher quand l��tape est finie
    //le bool indique true si la step est un "succ�s" false si la step est un "�chec"
    //ce qui veut dire qu'il faut recommencer le tuto
    [HideInInspector]
    public UnityEvent OnStepCompleted;
}