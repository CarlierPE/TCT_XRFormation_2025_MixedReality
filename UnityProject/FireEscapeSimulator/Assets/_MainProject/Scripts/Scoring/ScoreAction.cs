using System.Collections.Generic;

namespace TcT.FireSim
{
    public static class ScoreAction
    {
        public static Dictionary<eMonitoredAction, int> tableScoreAction = new()
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
        { eMonitoredAction.TimerOut, 0 },
    };

        public static string GetFrenchDescription(eMonitoredAction action)
        {
            switch (action)
            {
                case eMonitoredAction.PressAlarmButton:
                    return "Alarme incendie";
                case eMonitoredAction.WalkIntoFire:
                    return "Contact avec le feu";
                case eMonitoredAction.CloseDoor:
                    return "Porte coupe-feu";
                case eMonitoredAction.FinishLine:
                    return "Succès";
                case eMonitoredAction.TimerOut:
                    return "Temps écoulé";
                default:
                    return null;
            }
        }
    }
}