using NUnit.Framework;
using UnityEngine;

public class TEST_TestStep : TutorialStep
{
    public override void StartStep()
    {
        Debug.Log("TestStep has started");
        OnStepCompleted?.Invoke(true);
        Debug.Log("TestStep has fired its event");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
