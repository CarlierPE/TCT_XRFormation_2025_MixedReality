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
    public UnityEvent OnCalibrationValidated;
    public UnityEvent OnCalibrationFailed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
