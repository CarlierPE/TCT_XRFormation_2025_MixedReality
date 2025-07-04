using UnityEngine;

public class CanvasFollowCamera : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject canvasObject;
    [SerializeField] Vector3 offset = new Vector3(0, 0, 1f);

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
        canvasObject.transform.position = mainCamera.transform.position + mainCamera.transform.rotation * offset;
        canvasObject.transform.rotation = mainCamera.transform.rotation;
    }

    void Update()
    {
        if (canvasObject != null && !canvasObject.activeSelf)
        {
            canvasObject.transform.position = mainCamera.transform.position + mainCamera.transform.rotation * offset;
            canvasObject.transform.rotation = mainCamera.transform.rotation;
        }
    }

    // Appelés par un autre script ou bouton
    public void ShowCanvas()
    {
        canvasObject.SetActive(true); // Le canvas ne suit plus une fois actif
    }

    public void HideCanvas()
    {
        canvasObject.SetActive(false); // Le canvas suit la caméra en arrière-plan
    }
}