using System.Collections.Generic;
using JetBrains.Annotations;
using Meta.WitAi.Events;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private List<TutorialStep>_tutorialStep  = new();
    private int _currentStepIndex;
    public StepFinish StepFinish;
    public void StartTutorial()
    {
        _currentStepIndex = 0;
        _tutorialStep[_currentStepIndex].StartStep();
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
        _currentStepIndex++;
        if (_currentStepIndex < _tutorialStep.Count)
        {
            Debug.Log("index : " +  _currentStepIndex);
            
            _tutorialStep[_currentStepIndex].StartStep();
        }
        else
        {
            StepFinish?.finish();    
        }
    }
}
