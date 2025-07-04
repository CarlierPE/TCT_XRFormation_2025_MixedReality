using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    Collider presser;
    private bool isPressed;
    [SerializeField] GameObject SpawnedSphere;


    void Start()
    {
        isPressed = false;
        
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider Other)
    {
        if (!isPressed)
        {

            button.transform.localPosition = new Vector3(0, 1.57f, 0);
            presser = Other;
            onPress.Invoke();
            isPressed = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        
        if (other == presser)
        {
            
            button.transform.localPosition = new Vector3(0, 1.65f,0);
           
            onRelease.Invoke();
            isPressed=false;    
        }
    }
    public void SpawnSphere()
    {
        GameObject sphere= GameObject.CreatePrimitive(PrimitiveType.Sphere);
        
        sphere.transform.localScale = new Vector3(1f, 1f, 1f);
       
        sphere.transform.localPosition = new Vector3(1f,1,1f);
       sphere.AddComponent<Rigidbody>();
       

    }


}
