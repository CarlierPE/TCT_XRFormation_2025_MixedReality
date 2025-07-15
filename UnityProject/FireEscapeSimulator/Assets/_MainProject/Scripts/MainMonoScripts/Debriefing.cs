using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TcT.FireSim
{

    /*
     * Ce script va gérer l'affichage du score à l'utilisateur
     * Càd toutes ses actions, bonnes et mauvaises, son timing, son score final etc...
     * Possible que cet écran ait besoin du guide ? à confirmer
     * 
     * L'utilisateur aura un bouton à disposition "terminer la partie" ou "retour au menu"
     * Le script doit déclencher un unityevent quand le bouton est cliqué
     * */
    public class Debriefing : MonoBehaviour
    {
        [HideInInspector]
        public UnityEvent OnDebriefingExited;

        [SerializeField] Button _okButton;
        [SerializeField] GameObject _debriefingUI;

        private void OnEnable()
        {
            _debriefingUI.SetActive(true);
            _okButton.onClick.AddListener(ExitGame);
        }

        private void OnDisable()
        {
            _debriefingUI.SetActive(false);
            _okButton.onClick.RemoveListener(ExitGame);
        }

        private void ExitGame()
        {
            OnDebriefingExited.Invoke();
        }
    }
}