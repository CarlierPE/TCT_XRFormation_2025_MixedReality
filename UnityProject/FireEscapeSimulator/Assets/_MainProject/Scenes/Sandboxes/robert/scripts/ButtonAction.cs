using TMPro;
using UnityEngine;

public class MyButtonAction : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void Activer()
    {
        Debug.Log("Bouton press� !");
        text.text = "Bouton press� !";
        // Mets ici ton action : charger une sc�ne, activer un objet, etc.
    }
}