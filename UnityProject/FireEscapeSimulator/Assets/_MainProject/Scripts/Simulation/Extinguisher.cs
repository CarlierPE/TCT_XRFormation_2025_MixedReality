namespace TcT.FireSim
{
    public class Extinguisher : TriggerableByPlayer
    {
        public void PutOutTheFire()
        {
            OnTriggeredByPlayer(eMonitoredAction.ExtinguisherPutOut);
        }

    }
}