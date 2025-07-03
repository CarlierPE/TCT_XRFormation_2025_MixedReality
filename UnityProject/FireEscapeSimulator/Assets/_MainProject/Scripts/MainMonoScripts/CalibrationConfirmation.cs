using UnityEngine;
using UnityEngine.Events;

/*
 * Ce script demande à l'utilisateur si la pièce est calibrée correctement.
 * Il a donc une UI pour afficher le message, mais aussi un "marqueur" (sans doute une sphère semi transparente) à afficher
 * sur la gommette que l'utilisateur est censé avoir fixée
 * UnityEvent si l'utilisateur répond OK
 * un autre UnityEvent si l'utilisateur répond que ce n'est pas bon
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
