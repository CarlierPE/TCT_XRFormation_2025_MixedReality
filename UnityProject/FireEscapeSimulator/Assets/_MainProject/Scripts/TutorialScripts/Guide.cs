using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Guide : MonoBehaviour
{
    /*
     * will contain public methods to control the guide animations etc
     * maybe a "moveto" or something? we will see how intelligence is balanced between the guide itself
     * and the path manager 
     * 
     */

    [SerializeField] Transform _pictoContainer;
    private TutorialPicto _currentPicto;
    private Animator _anim;
    public UnityEvent OnSpawnComplete;
    public UnityEvent OnPictoHidden;
    private SphereMovement _sphere; 
    private void Start()
    {
       
        _anim = GetComponent<Animator>();
        
    }
    private void Update()
    {
        if (_currentPicto == null)
            return;
        _currentPicto.transform.position = _pictoContainer.position;
        _currentPicto.transform.rotation = _pictoContainer.rotation;
    }
    public void Spawn(Vector3 spawnPosition, Transform lookAtTarget)
    {
        //se positionne à la position en regardant à lookattarget et joue son animation de spawn
        transform.position = spawnPosition;
        transform.LookAt(lookAtTarget, Vector3.up);
        //jouer animation ici
        //...
        OnSpawnComplete?.Invoke();
    }

    public void ShowPanel(TutorialPicto picto)
    {
        //jouer l'animation du casque qui s'ouvre et montrer le picto
        _currentPicto = picto;
    }

    public void HideCurrentPanel()
    {
        //jouer l'animation pour cacher le picto
        //...
        _currentPicto.gameObject.SetActive(false);
        _currentPicto = null;
        OnPictoHidden?.Invoke();
    }

    //Just to have an idea of which animations we will have...
    public void PlayBeginControl()
    {
        _anim.SetBool("Idle", false);
        _anim.SetBool("Depart", true);

    }
    public void PlayGoForwardAnimation()
    {
        

    }
    public void PlayGoBackwardAnimation() { }
    public void PlayIdleAnimation() 
    {
        _anim.SetBool("Idle", true);
        _anim.SetBool("Depart", false);

    }
    public void PlayTurnLeftAnimation() { }
    public void PlayTurnRightAnimation() { }

    public void WayEndAnimation()
    {
        
        _anim.SetBool("Open", true);
        Debug.Log("C'est vraiment finiiiiii");
    }
}