using UnityEngine;

namespace Ldm.Relocator
{
    public class RelocationAnchor : MonoBehaviour
    {
        public Vector3 Zero => transform.position;
        public Quaternion Identity => transform.rotation;        
    }
}