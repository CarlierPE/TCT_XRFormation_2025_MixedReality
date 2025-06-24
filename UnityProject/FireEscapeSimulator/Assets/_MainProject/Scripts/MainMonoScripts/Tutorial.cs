using UnityEngine;
using UnityEngine.Events;

/*
 * Script principal du tutorial.
 * Il devra gérer l'enchaînement de tout ce qui s'y passe, principalement gérer le guide, ses déplacements et animations,
 * les choix de dialogue de l'utilisateur ("as-tu compris? oui/non")
 * Ce script doit avoir 2 unityevents car l'utilisateur pourra choisir de rejouer l'intégralité du tutorial.
 * Donc un unityevent s'il choisit de continuer, un autre s'il choisit de recommencer.
 */
public class Tutorial : MonoBehaviour
{
    public UnityEvent OnTutorialValidated;
    public UnityEvent OnTutorialFailed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
