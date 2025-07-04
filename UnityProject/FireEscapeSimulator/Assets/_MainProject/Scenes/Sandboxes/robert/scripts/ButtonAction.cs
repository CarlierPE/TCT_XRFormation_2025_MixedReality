using TMPro;
using UnityEngine;

public class MyButtonAction : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void Activer()
    {
        Debug.Log("Bouton pressé !");
        text.text = "Bouton pressé !";
        // Mets ici ton action : charger une scène, activer un objet, etc.
    }
}