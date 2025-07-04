using System;
using UnityEngine;
using UnityEngine.Events;

/*
 * Script principal du tutorial.
 * Il devra g�rer l'encha�nement de tout ce qui s'y passe, principalement g�rer le guide, ses d�placements et animations,
 * les choix de dialogue de l'utilisateur ("as-tu compris? oui/non")
 * Ce script doit avoir 2 unityevents car l'utilisateur pourra choisir de rejouer l'int�gralit� du tutorial.
 * Donc un unityevent s'il choisit de continuer, un autre s'il choisit de recommencer.
 */
public class Tutorial : MonoBehaviour
{
    [SerializeField] TutorialManager _tutorialManager;
    [SerializeField] Guide _guide;

    [HideInInspector]
    public UnityEvent OnTutorialValidated;
    [SerializeField] GameObject _tutorialEnvironment;

    private void OnEnable()
    {
        _tutorialEnvironment.SetActive(true);
        _tutorialManager.OnLastStepCompleted.AddListener(CompleteTutorial);
        _tutorialManager.StartTutorial();
    }

    private void OnDisable()
    {
        _tutorialEnvironment.SetActive(false);
        _tutorialManager.OnLastStepCompleted.RemoveListener(CompleteTutorial);
    }

    private void CompleteTutorial()
    {
        _guide.UnSpawn();
        OnTutorialValidated.Invoke();
    }
}
