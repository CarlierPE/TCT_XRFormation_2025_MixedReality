using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SphereMovement : MonoBehaviour
{
    public UnityEvent _onPathCompleted;
    public UnityEvent _onPathWait;
    public UnityEvent _onPathContinue;
    [SerializeField] private List<Transform> _transformList = new();
    [SerializeField] private float _speed = 5f;
    [SerializeField] private GuideProvider _guideProvider;
    [SerializeField] private Transform _follower;
    [SerializeField] private float _distanceFollower = 3f;
    [SerializeField] private Transform firstCube;
    private bool _firstStart = false;
    private int _currentWaypointIndex = 0;
    private Guide _guide;
    private bool fini = false;
    private bool firstpos = true;
    private void Start()
    {
        _guide = _guideProvider.GetGuide();
        _guide.gameObject.SetActive(true);
        if (firstCube != null)
        {
            _guide.transform.position = firstCube.position;
            _currentWaypointIndex = 0;

        }

    }

    private void Update()
    {
        float distance = Vector3.Distance(_guide.transform.position, _follower.position);

        // Mode "regard" : une fois la fin atteinte, ou si le follower est trop loin
        if (fini || distance >= _distanceFollower)
        {
            ToLookPlayer();

            return;
        }

        // Mode "suivi de waypoints"
        if (!_firstStart) return;

        if (_currentWaypointIndex < _transformList.Count)
        {
            Transform target = _transformList[_currentWaypointIndex];
            _guide.transform.position = Vector3.MoveTowards(
                _guide.transform.position, target.position, _speed * Time.deltaTime
            );

            if (Vector3.Distance(_guide.transform.position, target.position) < 0.1f)
            {
                _currentWaypointIndex++;
                if (_currentWaypointIndex >= _transformList.Count)
                {
                    fini = true;
                    _onPathCompleted?.Invoke();
                    return;
                }


            }


            RotateTowards(target.position);


        }
    }

    private void ToLookPlayer()
    {
        RotateTowards(_follower.position);
    }

    private void RotateTowards(Vector3 destination)
    {
        Vector3 dir = (destination - _guide.transform.position).normalized;
        if (dir.sqrMagnitude < 0.0001f) return;
        Quaternion rot = Quaternion.LookRotation(dir, Vector3.up);
        _guide.transform.rotation = Quaternion.RotateTowards(
            _guide.transform.rotation, rot, 360f * Time.deltaTime
        );
        _onPathWait?.Invoke();
    }

    public void StarteAction()
    {
        _firstStart = true;
        _onPathContinue?.Invoke();
    }

    public void BreakAction()
    {
        _firstStart = false;
        _onPathWait?.Invoke();
        ToLookPlayer();
    }

    private void OnDrawGizmos()
    {
        if (_transformList == null || _transformList.Count < 2) return;
        Gizmos.color = Color.green;
        for (int i = 0; i < _transformList.Count - 1; i++)
        {
            if (_transformList[i] != null && _transformList[i + 1] != null)
                Gizmos.DrawLine(_transformList[i].position, _transformList[i + 1].position);
        }
    }
}