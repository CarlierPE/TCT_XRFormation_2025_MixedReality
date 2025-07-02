using System.Collections.Generic;
using UnityEngine;

public class StartAlarmDetector : MonoBehaviour
{

    [SerializeField] GameObject _fire;
    public List<AudioSource> _alarm;

    [SerializeField]private float _timeStartAlarm;

    private float _timeWaiting;
    private bool _soundIsPlaying;

    private void Awake()
    {
        _timeStartAlarm = 1f;
        _timeWaiting = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_fire.activeSelf)
        {
            if (_soundIsPlaying)
                return;

            if (_timeWaiting > _timeStartAlarm)
            {
                _soundIsPlaying = true;
                foreach (var item in _alarm)
                {
                    item.Play();
                }
            }
            else
            {
                _timeWaiting += Time.deltaTime;
            }
        }
        else
        {
            if (_soundIsPlaying)
            {
                foreach (var item in _alarm)
                {
                    item.Stop();
                }
                _soundIsPlaying= false;
            }

            _timeWaiting = 0;
        }


    }

    public void StartSound()
    {
        Debug.Log("entrer dans start sound");
        if (_alarm == null)
        {
            Debug.Log("entrer dans le if car _alarm est null");
            return;
        }
        Debug.Log("nombre d'element est " + _alarm.Count);
        foreach (var item in _alarm)
        {
            item.Play();
        }
    }

    public  void StopSound()
    {
        Debug.Log("entrer dans stop sound");
        if (_alarm == null)
        {
            Debug.Log("entrer dans le if car _alarm est null");
            return;
        }
        Debug.Log("nombre d'element est " + _alarm.Count);
        foreach (var item in _alarm)
        {
            item.Stop();
        }
    }

}
