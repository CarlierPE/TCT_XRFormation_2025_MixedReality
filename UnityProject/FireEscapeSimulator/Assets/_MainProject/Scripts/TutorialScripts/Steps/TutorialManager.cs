using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TcT.FireSim
{
    public class TutorialManager : MonoBehaviour
    {
        [SerializeField] private List<TutorialStep> _tutorialStep = new();
        private int _currentStepIndex;

        [HideInInspector]
        public UnityEvent OnLastStepCompleted;

        private TutorialStep CurrentStep => _tutorialStep[_currentStepIndex];

        public void StartTutorial()
        {
            _currentStepIndex = 0;
            CurrentStep.gameObject.SetActive(true);
            CurrentStep.StartStep();
        }

        void OnEnable()
        {
            foreach (var step in _tutorialStep)
            {
                step.OnStepCompleted.AddListener(OnCurrentStepCompleted);

            }
        }
        void OnDisable()
        {
            foreach (var step in _tutorialStep)
            {
                step.OnStepCompleted.RemoveListener(OnCurrentStepCompleted);

            }
        }
        void OnCurrentStepCompleted()
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
}