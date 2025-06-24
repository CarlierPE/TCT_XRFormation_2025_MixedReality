using Ldm.Relocator;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AnchorBasedRelocator))]
public class Calibration : MonoBehaviour
{
    public UnityEvent OnCalibration;
    private AnchorBasedRelocator _relocator;
    [SerializeField] GameObject _calibrationUI;
    [SerializeField] GameObject _calibrationVisor;
    [SerializeField] InputActionReference _calibrationConfirmationAction;
    private Transform _camTransform;
    private void Awake()
    {
        _relocator = GetComponent<AnchorBasedRelocator>();
        _camTransform = Camera.main.transform;
    }

    private void OnEnable()
    {
        _calibrationConfirmationAction.action.performed += OnCalibrationConfirmed;
        _calibrationUI.SetActive(true);
        _calibrationVisor.SetActive(true);
    }

    private Pose AnchorPose =>
        new Pose(
            new Vector3(_camTransform.position.x, 0f, _camTransform.position.z),
            Quaternion.Euler(0f, _camTransform.rotation.eulerAngles.y, 0f)
            );
    private void OnCalibrationConfirmed(InputAction.CallbackContext obj)
    {
        
        _relocator.Relocate(AnchorPose);
        OnCalibration?.Invoke();
    }

    private void OnDisable()
    {
        _calibrationConfirmationAction.action.performed -= OnCalibrationConfirmed;
        _calibrationUI.SetActive(false);
        _calibrationVisor.SetActive(false);
    }
}
