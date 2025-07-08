using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
    [SerializeField] Button _okButton;
    [SerializeField] Button _cancelButton;


    [HideInInspector]
    public UnityEvent OnCalibrationValidated;
    [HideInInspector]
    public UnityEvent OnCalibrationFailed;

    private void OnEnable()
    {
        _okButton.onClick.AddListener(ValidateCalibration);
        _cancelButton.onClick.AddListener(FailCalibration);
        _visualHelp.SetActive(true);
        _UI.SetActive(true);
    }

    private void OnDisable()
    {
        _okButton.onClick.RemoveListener(ValidateCalibration);
        _cancelButton.onClick.RemoveListener(FailCalibration);
        _visualHelp.SetActive(false);
        _UI.SetActive(false);
    }

    private void ValidateCalibration()
    {
        OnCalibrationValidated.Invoke();
    }

    private void FailCalibration()
    {
        OnCalibrationFailed.Invoke();
    }
}
