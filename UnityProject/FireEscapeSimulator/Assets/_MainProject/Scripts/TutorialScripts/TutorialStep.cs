using UnityEngine;
using UnityEngine.Events;

public abstract class TutorialStep : MonoBehaviour
{
    // Appelé pour démarrer l’étape
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
    // Événement à déclencher quand l’étape est finie
    //le bool indique true si la step est un "succès" false si la step est un "échec"
    //ce qui veut dire qu'il faut recommencer le tuto
    [HideInInspector]
    public UnityEvent OnStepCompleted;
}