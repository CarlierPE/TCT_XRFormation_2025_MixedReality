using UnityEngine;

namespace Ldm.Relocator
{
    public class TriangleBasedRelocatable : MonoBehaviour
    {
        [Header("Triangle vertices")]
        [SerializeField] Transform _vertex1;
        [SerializeField] Transform _vertex2;
        [SerializeField] Transform _vertex3;
        [Space(10)]
        [SerializeField] GameObject _objectToRelocate;
        [SerializeField] float _errorMargin = 0f;

        public float ErrorMargin => _errorMargin;
        public GameObject ObjectToRelocate => _objectToRelocate;
        public Triangle3D Triangle => new Triangle3D { A = _vertex1.position, B = _vertex2.position, C = _vertex3.position };

        private void OnValidate()
        {
            ForceDescendantOnly(ref _vertex1);
            ForceDescendantOnly(ref _vertex2);
            ForceDescendantOnly(ref _vertex3);
            ForceDescendantOnly(ref _objectToRelocate);
            _errorMargin = Mathf.Abs(_errorMargin);
        }

        private void ForceDescendantOnly(ref GameObject nodeToTest)
        {
            if (nodeToTest != null && !nodeToTest.transform.IsChildOf(transform))
            {
                Debug.LogWarning($"{nodeToTest.name} must be a descendant of {nodeToTest.name}. Resetting the reference.", this);
                nodeToTest = null;
            }
        }

        private void ForceDescendantOnly(ref Transform nodeToTest)
        {
            if (nodeToTest != null && !nodeToTest.transform.IsChildOf(transform))
            {
                Debug.LogWarning($"{nodeToTest.name} must be a descendant of {nodeToTest.name}. Resetting the reference.", this);
                nodeToTest = null;
            }
        }

#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            if (_vertex1 == null || _vertex2 == null || _vertex3 == null) return;
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(_vertex1.position, _vertex2.position);
            Gizmos.DrawLine(_vertex2.position, _vertex3.position);
            Gizmos.DrawLine(_vertex3.position, _vertex1.position);
        }
#endif
    }
}