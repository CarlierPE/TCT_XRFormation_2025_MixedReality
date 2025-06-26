using System;
using UnityEngine;

[Obsolete("ne pas utiliser on spawnera le guide dans le before_tutorial", true)]
public class GuideSpawnStep : TutorialStep
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] GuideProvider _guideProvider;

    private Guide _guide;
    public override void StartStep()
    {
        _guide.Spawn(_playerTransform.position + _playerTransform.forward + _playerTransform.right * -0.5f, _playerTransform);        
    }

    private void Awake()
    {
        _guide = _guideProvider.GetGuide();
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
        OnStepCompleted?.Invoke(true);
    }
}
