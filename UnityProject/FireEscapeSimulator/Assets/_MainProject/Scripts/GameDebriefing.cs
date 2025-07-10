using System;
using System.Collections.Generic;

namespace TcT.FireSim
{
    [Serializable]
    public class GameDebriefing
    {
        public float timeGame;
        public int scoreEnd;
        public List<ScoreLog> scoreLogs;
    }
}