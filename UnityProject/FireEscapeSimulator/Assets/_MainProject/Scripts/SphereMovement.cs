using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{


   
    [SerializeField] List<Transform> _transformList = new List<Transform>();
    [SerializeField]float _speed = 5f;
    [SerializeField] GuideProvider _guideProvider;
    private int _currentWaypointIndex = 0;
    private Guide _guide;
    private bool _start = false;
    private void Start()
    {
        _guide = _guideProvider.GetGuide();
        _guide.gameObject.SetActive(true);
    }


   
        void Update()
        {
            if (_start == true)
            {
                 Debug.Log("shit");
                 if (_transformList.Count == 0) return;

                 Transform target = _transformList[_currentWaypointIndex];
                 _guide.transform.position = Vector3.MoveTowards(
                 _guide.transform.position,
                 target.position,
                _speed * Time.deltaTime);

                 if (Vector3.Distance(_guide.transform.position, target.position) < 0.1f)
                 {
                     _currentWaypointIndex++;
                     if (_currentWaypointIndex >= _transformList.Count)
                     {
                         ResetAction();
                     }
                 }
            }
        }
        public void StarteAction()
        {
             _start = true;
        }
    public void BreakAction()
    {
        _start = false;
    }
    public void ResetAction()
    {
        
        _guide.transform.position =  _transformList[0].position;
        _currentWaypointIndex = 0;
    }
    void OnDrawGizmos()
        {
             if (_transformList == null || _transformList.Count < 2) return;

             Gizmos.color = Color.green;
             for (int i = 0; i < _transformList.Count - 1; i++)
             {
                 if (_transformList[i] != null && _transformList[i + 1] != null)
                 {
                Gizmos.DrawLine(_transformList[i].position, _transformList[i + 1].position);
                 }
             }
        }
}