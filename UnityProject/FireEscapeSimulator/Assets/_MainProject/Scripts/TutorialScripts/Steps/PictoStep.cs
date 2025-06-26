using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PictoStep : TutorialStep
{
    [SerializeField] GuideProvider _guideProvider;
    private Guide _guide;

    [SerializeField] SphereMovement _path;
    [SerializeField] GameObject _highlight;
    [SerializeField] TutorialPicto _picto;
    public override void StartStep()
    {
        _path.StarteAction();
    }


    private void Awake()
    {
        _guide = _guideProvider.GetGuide();
    }

    private void OnEnable()
    {
        _guide.OnPictoHidden.AddListener(pictoHidden);
        _path.OnPathCompleted.AddListener(pathCompleted);
        _picto.OnUserConfirmation.AddListener(pictoConfirmed);
    }

    private void pictoHidden()
    {
        OnStepCompleted?.Invoke(true);
    }

    private void pictoConfirmed()
    {
        _guide.HideCurrentPanel();
    }

    private void OnDisable()
    {
        _guide.OnPictoHidden.RemoveListener(pictoHidden);
        _path.OnPathCompleted.RemoveListener(pathCompleted);
        _picto.OnUserConfirmation.RemoveListener(pictoConfirmed);
    }

    private void pathCompleted()
    {
        _highlight.SetActive(true);
        _guide.ShowPanel(_picto);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
