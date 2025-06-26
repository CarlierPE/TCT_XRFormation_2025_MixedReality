//using NUnit.Framework;
//using System.Collections.Generic;
//using UnityEngine;


//public class SimulationSript : MonoBehaviour
//{
//    [SerializeField] List<GameObject> _fires;
//    [SerializeField] float _timeExpension;
//    [SerializeField] GameObject _prefabExtincteur;
//    [SerializeField] GameObject _prefabAlarm;
//    [SerializeField] List<GameObject> _noEntry;
//    [SerializeField] List<GameObject> _prefabDoor;
//    [SerializeField] GameObject _prefabPhone;

//    eMonitoredAction _actoin;
//    ScoreEndingShower _scoreGame;
//    FireInstancate _fireInstancate;
//    float _startGame;
    

//    private void Awake()
//    {
//        _fireInstancate = new();
//        _scoreGame = new();
//        _startGame = Time.time;

//        if (_fires != null)
//        {
//            foreach (GameObject fire in _fires)
//            {
//                fire.SetActive(false);
//            }
//            _fireInstancate.InstantieFire(_fires);
//        }
//        if (_timeExpension == 0)
//        {
//            _timeExpension = 5f;
//        }

//        _scoreGame = new ScoreEndingShower();
//        _fireInstancate = new FireInstancate();

//    }

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    public void OnStartSenario()
//    {
//        UpdateScoreSenario();
//    }

//    private void UpdateScoreSenario()
//    {

//    }

//    public void OnEndSenario()
//    {
        

//    }
//}
