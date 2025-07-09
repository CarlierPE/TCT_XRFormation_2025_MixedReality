using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private const float Max = 15f;
    public AudioSource touxSound;
    public AudioSource heartSound;
    public AudioSource respiationSound;
    public AudioSource respirationDifficultSound;

    private float _timeStart;
    private float _timeElpase;

    private void Awake()
    {
        _timeStart = Time.time;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeElpase = Time.time - _timeStart;

        if (_timeElpase == 5f)
        {
            touxSound.Play();
        }
        if (_timeElpase <= Max && _timeElpase > 5f)
        {
            heartSound.Play();
        }
        if(_timeElpase > 5f && _timeElpase < 7.5f)
            respiationSound.Play();
        else if (_timeElpase < Max &&  _timeElpase > 7.5f)
            respirationDifficultSound.Play();
    }
}
