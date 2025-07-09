using NUnit.Framework;
using UnityEngine;

public class TEST_TestStep : TutorialStep
{
    protected override void DoStep()
    {
        Debug.Log("TestStep has started");
        OnStepCompleted?.Invoke();
        Debug.Log("TestStep has fired its event");
    }

}
