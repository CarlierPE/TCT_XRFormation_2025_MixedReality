using UnityEngine;
using UnityEngine.Events;

/*
 * Ce script est prévu pour préparer le tutorial, les initialisation ou réinitialisation de ce dont le tutorial a besoin
 * Il doit avoir un UnityEvent pour signaler qu'il a terminé son travail (même s'il n'a rien à faire)
 */
public class BeforeTutorial : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnTutorialStarting;
    [SerializeField] GameObject _occlusion;
    [SerializeField] Guide _guide;
    [SerializeField] Transform _guideDefaultLocation;

    private void OnEnable()
    {
        _occlusion.SetActive(true);
        OnTutorialStarting.Invoke();
        _guide.transform.position = _guideDefaultLocation.position;
    }
}
