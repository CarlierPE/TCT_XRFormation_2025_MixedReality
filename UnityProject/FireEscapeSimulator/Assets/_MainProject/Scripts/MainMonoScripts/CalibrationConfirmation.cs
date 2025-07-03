using UnityEngine;
using UnityEngine.Events;

/*
 * Ce script demande � l'utilisateur si la pi�ce est calibr�e correctement.
 * Il a donc une UI pour afficher le message, mais aussi un "marqueur" (sans doute une sph�re semi transparente) � afficher
 * sur la gommette que l'utilisateur est cens� avoir fix�e
 * UnityEvent si l'utilisateur r�pond OK
 * un autre UnityEvent si l'utilisateur r�pond que ce n'est pas bon
 * */
public class CalibrationConfirmation : MonoBehaviour
{
    [SerializeField] GameObject _visualHelp;
    [SerializeField] GameObject _UI;
    [HideInInspector]
    public UnityEvent OnCalibrationValidated;
    [HideInInspector]
    public UnityEvent OnCalibrationFailed;

    private void OnEnable()
    {
        //TODO - 2 events de l'UI add
        _visualHelp.SetActive(true);
        _UI.SetActive(true);
    }

    private void OnDisable()
    {
        //TODO - 2 events de l'UI remove
        _visualHelp.SetActive(false);
        _UI.SetActive(false);
    }

    private void ValidateCalibration()
    {
        OnCalibrationValidated?.Invoke();
    }

    private void FailCalibration()
    {
        OnCalibrationFailed?.Invoke();
    }
}
