using System.Collections.Generic;
using UnityEngine;

public class ScoreAction
{
    public Dictionary<eMonitoredAction, int> tableScoreAction = new ()
    {
        { eMonitoredAction.OpenAlarmBox, 0 },
        { eMonitoredAction.PressAlarmButton, 300 },
        { eMonitoredAction.WalkIntoFire, -150 },
        { eMonitoredAction.CloseDoor, 20 },
        { eMonitoredAction.OpenDoor, -10 },
        { eMonitoredAction.FinishLine, 2500 },
        { eMonitoredAction.ExtinguisherTake,20},
        { eMonitoredAction.ExtinguisherPutOut,250},
        { eMonitoredAction.StairsUp,-150},
        { eMonitoredAction.TakePhone,20},
        { eMonitoredAction.Appel,150},
        { eMonitoredAction.TouchElevator,-200},
    };
}

