using UnityEngine;

public class PE_TestScript : TriggerableByPlayer
{
    
    void Start()
    {
        
    }

    //for debugging purposes - fires the event every 5 sec
    void Update()
    {
        if(((int)Time.realtimeSinceStartup)%5 == 0)
            OnTriggeredByPlayer(eMonitoredAction.WalkIntoFire);
    }
}