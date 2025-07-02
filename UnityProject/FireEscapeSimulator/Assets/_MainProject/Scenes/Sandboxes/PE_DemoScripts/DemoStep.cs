using System.Collections;
using UnityEngine;

public class DemoStep : TutorialStep
{
    [SerializeField] GameObject _itemToToggle;
    [SerializeField] float _timeToWait;

    public override void StartStep()
    {
        StartCoroutine(toggleDelayed());
    }

    IEnumerator toggleDelayed()
    {
        yield return new WaitForSeconds(_timeToWait);
        _itemToToggle.SetActive(!_itemToToggle.activeSelf);
        OnStepCompleted?.Invoke();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
