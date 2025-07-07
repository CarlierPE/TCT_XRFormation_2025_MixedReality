using UnityEngine;
using UnityEngine.Events;

public class OnTriggerAction : MonoBehaviour
{
    public string allowUniqueID = "default";
    public UnityEvent onCollision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        OnTriggerActionTagID Id = other.gameObject.GetComponent<OnTriggerActionTagID>();
        if (Id != null && Id.uniqueID == allowUniqueID)
            onCollision.Invoke();
    }


}
