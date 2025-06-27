using UnityEditor.UI;
using UnityEngine;

public class lookDirectionObject : MonoBehaviour
{
    [SerializeField] private Transform fireMan;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        fireMan.transform.LookAt(fireMan.transform.position, fireMan.transform.forward);
    }

    // Update is called once per frame
    
}
