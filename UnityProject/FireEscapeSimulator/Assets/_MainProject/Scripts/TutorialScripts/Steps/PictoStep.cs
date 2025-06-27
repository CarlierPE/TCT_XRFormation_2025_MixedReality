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
    bool _success;
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
        _picto.OnUserCancellation.AddListener(pictoFailed);
    }

    private void pictoHidden()
    {
        _highlight?.SetActive(false);
        OnStepCompleted?.Invoke(_success);
    }

    private void pictoConfirmed()
    {
        _success = true;
        _guide.HideCurrentPanel();
    }

    private void pictoFailed()
    {
        _success = false;
        _guide.HideCurrentPanel();
    }

    private void OnDisable()
    {
        _guide.OnPictoHidden.RemoveListener(pictoHidden);
        _path.OnPathCompleted.RemoveListener(pathCompleted);
        _picto.OnUserConfirmation.RemoveListener(pictoConfirmed);
        _picto.OnUserCancellation.RemoveListener(pictoFailed);
    }

    private void pathCompleted()
    {
        _highlight?.SetActive(true);
        _guide.ShowPanel(_picto);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
