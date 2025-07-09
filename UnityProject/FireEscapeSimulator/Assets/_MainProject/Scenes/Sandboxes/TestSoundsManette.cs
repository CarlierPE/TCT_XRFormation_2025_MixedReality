using UnityEngine;
using UnityEngine.InputSystem;

public class TestSoundsManette : MonoBehaviour
{
    [SerializeField] private InputActionReference _alarmBox;
    [SerializeField] private InputActionReference _sound;
    [SerializeField] private InputActionReference _pressButton;

    [SerializeField] private PressButton _button;
    [SerializeField] private StartAlarmDetector _detec;
    [SerializeField] private StartAlarmBox _box;

    bool _boxPress;
    bool _DetPress;
    int _buttonCountPress = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _alarmBox.action.performed += ctx => SoundBox();
        _sound.action.performed += ctx => SoundDetec();
        _pressButton.action.performed += ctx => SoundButton();
        _boxPress = false;
        _DetPress = false;   
    }

    private void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SoundButton();
        }
    }

    public void SoundBox()
    {
        Debug.Log(_boxPress);
        _boxPress = true;
        Debug.Log(_boxPress);
        if (_boxPress)
        {
            _box.StartSound();
        }
        else
        {
            _box.StopSound();
            _boxPress = false;
        }

        Debug.Log(_boxPress);
    }

    public void SoundDetec()
    {
        Debug.Log(_DetPress);
        if (!_DetPress)
        {
            _detec.StartSound();
            _DetPress = true;
        }
        else
        {
            _detec.StopSound();
            _DetPress = false;
        }

        Debug.Log(_DetPress);
    }

    public void SoundButton()
    {
        if (_buttonCountPress == 0)
        {
            _button.StartSound();
            _boxPress = true;
            _buttonCountPress++;
        }

        Debug.Log(_buttonCountPress);
        
    }
}
