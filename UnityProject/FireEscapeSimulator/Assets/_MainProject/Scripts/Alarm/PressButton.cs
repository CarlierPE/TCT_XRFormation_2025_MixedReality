using UnityEngine;

public class PressButton : MonoBehaviour
{
    [SerializeField] AudioSource[] _audio;
    
    public void OnPress()
    {
        foreach (var item in _audio)
        {
            item.Play();
            StartAlarmBox.StartSound();
        }
    }
}
