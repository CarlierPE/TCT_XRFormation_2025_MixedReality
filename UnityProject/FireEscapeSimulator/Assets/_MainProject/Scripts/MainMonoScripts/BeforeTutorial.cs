using UnityEngine;
using UnityEngine.Events;

/*
 * Ce script est pr�vu pour pr�parer le tutorial, les initialisation ou r�initialisation de ce dont le tutorial a besoin
 * Il doit avoir un UnityEvent pour signaler qu'il a termin� son travail (m�me s'il n'a rien � faire)
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
