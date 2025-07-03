using System;
using UnityEngine;

public class GuideSpawnStep : TutorialStep
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] Guide _guide;
    public override void StartStep()
    {
        _guide.Spawn(_playerTransform.position + _playerTransform.forward + _playerTransform.right * -0.5f, _playerTransform);        
    }

    private void OnEnable()
    {
        _guide.OnSpawnComplete.AddListener(OnGuideSpawned);
    }

    private void OnDisable()
    {
        _guide.OnSpawnComplete.RemoveListener(OnGuideSpawned);

    }

    private void OnGuideSpawned()
    {
        OnStepCompleted?.Invoke();
    }
}
