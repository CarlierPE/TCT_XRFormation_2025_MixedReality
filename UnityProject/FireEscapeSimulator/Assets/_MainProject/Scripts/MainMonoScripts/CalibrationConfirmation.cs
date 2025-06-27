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
    public UnityEvent OnCalibrationValidated;
    public UnityEvent OnCalibrationFailed;
    [SerializeField] GameObject _confirmationIndicator;
    [SerializeField] GameObject _confirmationUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        _confirmationIndicator?.SetActive(true);
    }
    private void OnDisable()
    {
        _confirmationIndicator?.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
