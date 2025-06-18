using UnityEngine;

namespace FireSim.SSM
{
    public abstract class GameState
    {
        public abstract eGameStateID ID { get; }

        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void OnUpdate() { }
        public abstract bool CanTransitionTo(eGameStateID nextState);
    }
}