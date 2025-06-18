using UnityEngine;
namespace FireSim.SSM
{
    public enum eGameStateID
    {
        Started,
        Uncalibrated,
        Calibrated,
        BeforeTutorial,
        Tutorial,
        AfterTutorial,
        BeforeSimulation,
        Simulation,
        AfterSimulation,
        Debriefing,
    }
}
