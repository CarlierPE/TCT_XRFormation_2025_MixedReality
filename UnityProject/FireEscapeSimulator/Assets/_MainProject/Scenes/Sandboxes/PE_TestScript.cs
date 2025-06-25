using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PE_TestScript : TriggerableByPlayer
{
    void osef()
    {
        TutorialStep tutorialStep = new SphereMovement();

        osef2(tutorialStep);

    }


    void osef2(TutorialStep step)
    {
        step.StartStep();
    }
    //for debugging purposes - fires the event every 5 sec
    void Update()
    {
        if(((int)Time.realtimeSinceStartup)%5 == 0)
            OnTriggeredByPlayer(eMonitoredAction.WalkIntoFire);
    }
}