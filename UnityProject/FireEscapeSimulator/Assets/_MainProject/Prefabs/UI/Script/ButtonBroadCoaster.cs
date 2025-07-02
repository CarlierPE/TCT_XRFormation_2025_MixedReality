using UnityEngine;
using UnityEngine.Events;

public class ButtonBroadcaster : MonoBehaviour
{
    public UnityEvent onButtonPressed;

    public void TriggerButton()
    {
        Debug.Log("Bouton appuyé !");
        onButtonPressed.Invoke();
    }
}