using System;
using UnityEngine;

[Obsolete("mauvaise idée, on va mettre un guide dans la scène et y aller de façon plus classique")]
public class GuideProvider : MonoBehaviour
{
    [SerializeField] Guide _guidePrefab;
    static Guide _guideInstance;

    static GuideProvider _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        _instance = this;
        _guideInstance = Instantiate(_guidePrefab);
        _guideInstance.gameObject.SetActive(false);
    }

    public Guide GetGuide() => _guideInstance;
}
