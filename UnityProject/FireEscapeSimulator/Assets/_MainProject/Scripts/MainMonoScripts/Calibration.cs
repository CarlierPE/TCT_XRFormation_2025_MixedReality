using Ldm.Relocator;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AnchorBasedRelocator))]
public class Calibration : MonoBehaviour
{
    private AnchorBasedRelocator _relocator;
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
    }

    private Pose AnchorPose =>
        new Pose(
            new Vector3(_camTransform.position.x, 0f, _camTransform.position.z),
            Quaternion.Euler(0f, _camTransform.rotation.eulerAngles.y, 0f)
            );
    private void OnCalibrationConfirmed(InputAction.CallbackContext obj)
    {
        
        _relocator.Relocate(AnchorPose);
    }

    private void OnDisable()
    {
        _calibrationConfirmationAction.action.performed -= OnCalibrationConfirmed;
    }
}
