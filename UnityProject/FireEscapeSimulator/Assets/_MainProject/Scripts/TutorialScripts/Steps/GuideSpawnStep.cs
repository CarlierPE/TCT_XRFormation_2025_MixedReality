using UnityEngine;
using UnityEngine.UI;

namespace TcT.FireSim
{
    public class GuideSpawnStep : TutorialStep
    {
        [SerializeField] Transform _playerTransform;
        [SerializeField] Guide _guide;
        [SerializeField] GameObject _picto;
        [SerializeField] Button _confirmButton;
        bool _spawned = false;
        bool _panelShown = false;

        protected override void OnUpdate()
        {
            if (_spawned && !_panelShown)
            {
                _guide.ShowPanel();
                _panelShown = true;
            }
        }
        protected override void DoStep()
        {
            _guide.Spawn(_playerTransform);
        }

        private void OnEnable()
        {
            _guide.OnSpawnComplete.AddListener(OnGuideSpawned);
            _guide.OnPictoHidden.AddListener(PictoHidden);
            _confirmButton.onClick.AddListener(PictoConfirmed);

        }

        private void OnDisable()
        {
            _guide.OnSpawnComplete.RemoveListener(OnGuideSpawned);
            _guide.OnPictoHidden.RemoveListener(PictoHidden);
            _confirmButton.onClick.RemoveListener(PictoConfirmed);
            _spawned = false;
            _panelShown = false;
        }

        private void PictoHidden()
        {
            OnStepCompleted?.Invoke();
        }

        private void PictoConfirmed()
        {
            _guide.HideCurrentPanel();
        }

        private void OnGuideSpawned()
        {
            //OnStepCompleted?.Invoke();
            _spawned = true;
        }
    }
}