public class TakeExtinguisher : TriggerableByPlayer
{
    public void TrapExtinguisher()
    {
        OnTriggeredByPlayer(eMonitoredAction.ExtinguisherTake);
    }
}
