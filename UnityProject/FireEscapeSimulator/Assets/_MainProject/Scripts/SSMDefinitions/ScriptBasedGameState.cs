using System;
using UnityEngine;
namespace FireSim.SSM
{
    public abstract class ScriptBasedGameState : GameState
    {
        protected MonoBehaviour _script;

        public ScriptBasedGameState(MonoBehaviour script)
        {
            if(script == null) throw new ArgumentNullException(nameof(script));
            _script = script;
        }

        public override void OnEnter()
        {
            _script.gameObject.SetActive(true);
            base.OnEnter();
        }

        public override void OnExit()
        {
            _script.gameObject.SetActive(false);
            base.OnExit();
        }
    }
}
