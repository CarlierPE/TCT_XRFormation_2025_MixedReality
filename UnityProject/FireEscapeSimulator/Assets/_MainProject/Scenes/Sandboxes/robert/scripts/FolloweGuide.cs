using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class FolloweGuide : MonoBehaviour
{
    [SerializeField] private GestionnaireDeTrajet gestionnaire;
    [SerializeField] private float vitesse = 0.1f;
    [SerializeField] private float seuilDistance = 0.1f;

    private int trajetActuelIndex = 0;
    private int pointIndex = 0;
    private bool enDeplacement = false;


}
