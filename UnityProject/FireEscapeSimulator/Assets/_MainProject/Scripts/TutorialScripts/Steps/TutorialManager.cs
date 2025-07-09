using System.Collections.Generic;
using JetBrains.Annotations;
using Meta.WitAi.Events;
using UnityEngine;
using UnityEngine.Events;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private List<TutorialStep> _tutorialStep = new();
    private int _currentStepIndex;

    [HideInInspector]
    public UnityEvent OnLastStepCompleted;
    //[HideInInspector]
    //public UnityEvent OnTutorialFailed;
    private TutorialStep CurrentStep => _tutorialStep[_currentStepIndex];

    public void StartTutorial()
    {
        _currentStepIndex = 0;
        CurrentStep.gameObject.SetActive(true);
        CurrentStep.StartStep();
    }

    public void OnEnable()
    {
        foreach (var step in _tutorialStep)
        {
            step.OnStepCompleted.AddListener(OnCurrentStepcompleted);

        }
    }
    public void OnDisable()
    {
        foreach (var step in _tutorialStep)
        {
            step.OnStepCompleted.RemoveListener(OnCurrentStepcompleted);

        }
    }
    public void OnCurrentStepcompleted()
    {
        Debug.Log($"Step {_currentStepIndex} completed");
        CurrentStep.gameObject.SetActive(false);
        _currentStepIndex++;
        if (_currentStepIndex < _tutorialStep.Count)
        {
            CurrentStep.gameObject.SetActive(true);
            CurrentStep.StartStep();
        }
        else
        {
            OnLastStepCompleted?.Invoke();
        }
    }
}
