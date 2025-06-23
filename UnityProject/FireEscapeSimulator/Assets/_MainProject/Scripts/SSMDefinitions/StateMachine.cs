using FireSim.SSM;
using System;
using System.Collections.Generic;

namespace FireSim.SSM
{
    public class StateMachine
    {
        private Dictionary<eGameStateID, GameState> _states = new();
        private GameState _currentState;

        public eGameStateID CurrentStateID => _currentState?.ID ?? default;

        public StateMachine AddState(GameState state)
        {
            _states[state.ID] = state;
            return this;
        }

        public StateMachine SetInitialState(eGameStateID stateID)
        {
            if (_currentState != null)
                throw new InvalidOperationException("State Machine is already running");

            if (_states.TryGetValue(stateID, out var state))
            {
                _currentState = state;
                _currentState.OnEnter();
            }
            return this;
        }

        public void ChangeState(eGameStateID newStateID)
        {
            if (_currentState != null && !_currentState.CanTransitionTo(newStateID))
                return;

            if (_states.TryGetValue(newStateID, out var newState))
            {
                _currentState?.OnExit();
                _currentState = newState;
                _currentState.OnEnter();
            }
        }
    }
}