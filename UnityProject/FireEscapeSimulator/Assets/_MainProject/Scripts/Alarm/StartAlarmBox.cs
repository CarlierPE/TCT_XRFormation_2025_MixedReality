using System.Collections.Generic;
using UnityEngine;

public class StartAlarmBox : MonoBehaviour 
{
    public List<AudioSource> _alarm;

    public void StartSound()
    {
        Debug.Log("entrer dans start sound");
        if (_alarm == null)
        {
            Debug.Log("entrer dans le if car _alarm est null");
            return;
        }
        Debug.Log("nombre d'element est " +  _alarm.Count);
        foreach (AudioSource source in _alarm)
        {
            source.Play();
        }
    }

    public void StopSound()
    {
        Debug.Log("entrer dans stop sound");
        if (_alarm == null)
        {
            Debug.Log("entrer dans le if car _alarm est null");
            return;
        }
        Debug.Log("nombre d'element est " + _alarm.Count);
        foreach (AudioSource source in _alarm)
        { 
            source.Stop(); 
        }
    }
}
