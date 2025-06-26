using UnityEngine;

namespace FireSim.SSM
{
    public abstract class GameState : MonoBehaviour
    {
        public abstract eGameStateID ID { get; }

        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public abstract bool CanTransitionTo(eGameStateID nextState);

        public virtual void OnUpdate() { }
    }
}