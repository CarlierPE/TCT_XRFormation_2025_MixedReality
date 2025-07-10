using System;

namespace TcT.FireSim
{
    [Serializable]
    public class ScoreLog
    {
        public float timeAction;
        public eMonitoredAction action;
        public int scoreValid;
    }
}