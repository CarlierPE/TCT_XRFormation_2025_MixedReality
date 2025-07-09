using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
/*
 *  Le but de ce script est d'afficher l'UI du tout premier menu quand on ouvre l'application
 *  L'UI doit disposer d'un bouton start
 *  Ce script doit avoir un UnityEvent qui se déclenche quand le user clique sur le bouton de l'UI
 */
public class StartScript : MonoBehaviour
{
    [SerializeField] GameObject _ui;
    [SerializeField] Button _startButton;

    [HideInInspector]
    public UnityEvent OnSessionStart;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartSession);
        _ui.SetActive(true);
    }

    private void StartSession()
    {
        OnSessionStart.Invoke();
    }
    
    private void OnDisable()
    {
        _ui.SetActive(false);
        _startButton.onClick.RemoveListener(StartSession);

    }
}
