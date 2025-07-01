using System.Media;
using Unity.Profiling;
using UnityEngine;

public class StartAlarmDetector : MonoBehaviour
{

    [SerializeField] GameObject _fire;
    [SerializeField] AudioSource[] _alarm;

    [SerializeField]private float _timeStartAlarm;
    private float _timeWaiting;
    private eMonitoredAction _action1;
    private eMonitoredAction _action2;
    private eMonitoredAction _action3;
    private bool _soundIsPlaying;

    private void Awake()
    {
        _timeStartAlarm = 1f;
        _timeWaiting = 0;
        _action1 = eMonitoredAction.FinishLine;
        _action2 = eMonitoredAction.WalkIntoFire;
        _action3 = eMonitoredAction.StairsUp;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
                StartAlarmBox.StartSound();
            }

            _timeWaiting = 0;
        }


    }

}
