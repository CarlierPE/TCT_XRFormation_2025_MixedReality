using System.Collections;
using UnityEngine;

public class DemoStep : TutorialStep
{
    [SerializeField] GameObject _itemToToggle;
    [SerializeField] float _timeToWait;

    public override void StartStep()
    {
        StartCoroutine(ToggleDelayed());
    }

    IEnumerator ToggleDelayed()
    {
        yield return new WaitForSeconds(_timeToWait);
        _itemToToggle.SetActive(!_itemToToggle.activeSelf);
        OnStepCompleted.Invoke();
    }
}
