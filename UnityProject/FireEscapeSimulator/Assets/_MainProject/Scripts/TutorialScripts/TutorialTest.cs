using UnityEngine;

public abstract class Way: MonoBehaviour

{
    public float _speed = 5f;

    public abstract Vector3 GetNextTargetPosition(Vector3 currentPosition, float deltaTime);
}
