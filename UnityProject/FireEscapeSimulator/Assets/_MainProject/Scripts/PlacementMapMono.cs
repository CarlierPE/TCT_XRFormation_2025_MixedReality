using UnityEngine;
using UnityEngine.InputSystem;

public class PlacementMapMono : MonoBehaviour
{
    [SerializeField] private GameObject map;
    [SerializeField] private InputActionReference relocationAction;
    private Camera _mainCamera;
    private Vector3 _placementMap;
    private Quaternion _placementMapRotation;

    void Awake()
    {
        // Initialize the main camera
        _mainCamera = Camera.main;
        if (_mainCamera == null)
        {
            Debug.LogError("Main camera not found. Please ensure there is a camera tagged as 'MainCamera' in the scene.");
        }
        Vector3 positionSol = _mainCamera.transform.position;
        positionSol.y = positionSol.y - _mainCamera.transform.position.y; // Adjust the Y position to be above the camera
        // Initialize the placement map position
        _placementMap = positionSol; // Default position, can be modified later
        _placementMapRotation = _mainCamera.transform.rotation; // Default rotation, can be modified later
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        relocationAction.action.performed += ctx => OnPresse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPresse()
    {
        Instantiate(map, _placementMap,_placementMapRotation);
    }
}
