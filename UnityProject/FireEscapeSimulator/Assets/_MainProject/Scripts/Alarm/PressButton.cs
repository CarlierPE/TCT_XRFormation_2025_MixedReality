using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    public List<AudioSource> _audio;
    
    [SerializeField] private StartAlarmBox _box;
    public void OnPress()
    {
        
        if (_box == null)
            return;
        foreach (var item in _audio)
        {
            item.Play();
        }
        _box.StartSound();
    }

    public void StartSound()
    {
        Debug.Log("entrer dans start foud");
        if (_audio == null)
        {
            Debug.Log("entrer dans le if car _ausio est null");
            return;
        }

        Debug.Log("nombre d'element est de " + _audio.Count);
        foreach (var item in _audio)
        {
            item.Play();
        }
        _box.StartSound();
    }
}
