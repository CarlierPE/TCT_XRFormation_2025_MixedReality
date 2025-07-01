using UnityEngine;

public class StartAlarmBox : MonoBehaviour 
{
    [SerializeField] static AudioSource[] _alarm;

    public static void StartSound()
    {
        foreach (AudioSource source in _alarm)
        {
            source.Play();
        }
    }

    public static void StopSound()
    {
        foreach (AudioSource source in _alarm)
        { 
            source.Stop(); 
        }
    }
}
