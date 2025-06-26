using UnityEngine;

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
    }

    public void ShowPanel(TutorialPicto picto)
    {
        //jouer l'animation du casque qui s'ouvre et montrer le picto
        _currentPicto = picto;
    }

    public void HideCurrentPanel()
    {
        //jouer l'animation pour cacher le picto
        _currentPicto = null;
    }

    //Just to have an idea of which animations we will have...
    public void PlayGoForwardAnimation() { }
    public void PlayGoBackwardAnimation() { }
    public void PlayIdleAnimation() { }
    public void PlayTurnLeftAnimation() { }
    public void PlayTurnRightAnimation() { }
}