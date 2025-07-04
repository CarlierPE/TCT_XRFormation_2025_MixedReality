using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PictoStep : TutorialStep
{
    [SerializeField] Guide _guide;

    [SerializeField] SphereMovement _path;
    [SerializeField] GameObject _highlight;
    [SerializeField] GameObject _picto;
    [SerializeField] ButtonBroadcaster _confirmButton;
    public override void StartStep()
    {
        if (_path == null)
        {
            PathCompleted();
            return;
        }
        _path.gameObject.SetActive(true);
        _path.StarteAction();
    }


    private void OnEnable()
    {
        _guide.OnPictoHidden.AddListener(PictoHidden);
        _confirmButton.onButtonPressed.AddListener(PictoConfirmed);
        if(_path != null )
            _path.OnPathCompleted.AddListener(PathCompleted);
    }

    private void PictoHidden()
    {
        if(_highlight != null)
            _highlight.SetActive(false);
        if (_path != null)
            _path.gameObject.SetActive(false);

        OnStepCompleted?.Invoke();
    }

    private void PictoConfirmed()
    {
        _guide.HideCurrentPanel();
    }


    private void OnDisable()
    {
        _guide.OnPictoHidden.RemoveListener(PictoHidden);
        _confirmButton.onButtonPressed.RemoveListener(PictoConfirmed);
        if (_path != null )
            _path.OnPathCompleted.RemoveListener(PathCompleted);
    }

    private void PathCompleted()
    {
        if(_highlight != null)
            _highlight.SetActive(true);
        _guide.ShowPanel(_picto);
    }

}
