using UnityEngine;
using UnityEngine.Events;

/*
 * Ce script va g�rer l'affichage du score � l'utilisateur
 * C�d toutes ses actions, bonnes et mauvaises, son timing, son score final etc...
 * Possible que cet �cran ait besoin du guide ? � confirmer
 * 
 * L'utilisateur aura un bouton � disposition "terminer la partie" ou "retour au menu"
 * Le script doit d�clencher un unityevent quand le bouton est cliqu�
 * */
public class Debriefing : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnDebriefingExited;

    private void OnEnable()
    {
        //TODO - afficher l'UI etc
        OnDebriefingExited?.Invoke();
    }
}
