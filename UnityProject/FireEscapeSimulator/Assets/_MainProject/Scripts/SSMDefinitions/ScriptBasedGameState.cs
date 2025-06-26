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
            _script.gameObject.SetActive(false);
        }

        public override void OnEnter()
        {
#if UNITY_EDITOR
            Debug.Log("Enter");
#endif
            _script.gameObject.SetActive(true);
            base.OnEnter();
        }

        public override void OnExit()
        {
#if UNITY_EDITOR
            Debug.Log("Exit");
#endif
            _script.gameObject.SetActive(false);
            base.OnExit();
        }
    }
}
