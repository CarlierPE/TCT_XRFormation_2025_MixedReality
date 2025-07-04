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
    private void Start()
    {
       
        _anim = GetComponent<Animator>();
        
    }
    private void Update()
    {
        if (_currentPicto == null)
            return;
        _currentPicto.transform.SetPositionAndRotation(_pictoContainer.position, _pictoContainer.rotation);
    }
    public void Spawn(Vector3 spawnPosition, Transform lookAtTarget)
    {
        //se positionne à la position en regardant à lookattarget et joue son animation de spawn
        transform.position = spawnPosition;
        transform.LookAt(lookAtTarget, Vector3.up);
        gameObject.SetActive(true);
        //jouer animation ici
        //...
        OnSpawnComplete?.Invoke();
    }

    public void UnSpawn()
    {
        //jouer animation éventuelle
        gameObject.SetActive(false);
    }

    public void ShowPanel(TutorialPicto picto)
    {
        //jouer l'animation du casque qui s'ouvre et montrer le picto
        _currentPicto = picto;
        _anim.SetBool("Open", true);
    }

    public void HideCurrentPanel()
    {
        //jouer l'animation pour cacher le picto
        //...
        _anim.SetBool("Open", false);
        _currentPicto.gameObject.SetActive(false);
        _currentPicto = null;
        OnPictoHidden?.Invoke();
    }

    //Just to have an idea of which animations we will have...
   
    public void PlayGoForwardAnimation()
    {
        _anim.SetBool("Run",true);
        
        
    }
    public void PlayGoBackwardAnimation() { }
    public void PlayIdleAnimation() 
    {
        
        _anim.SetBool("Run",false);

    }
    public void PlayTurnLeftAnimation() { }
    public void PlayTurnRightAnimation() { }

    
}