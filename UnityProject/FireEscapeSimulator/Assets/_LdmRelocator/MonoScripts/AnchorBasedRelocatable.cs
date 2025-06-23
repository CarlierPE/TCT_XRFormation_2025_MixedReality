using UnityEngine;
namespace Ldm.Relocator
{
    public class AnchorBasedRelocatable : MonoBehaviour
    {
        [SerializeField] RelocationAnchor _anchor;
        public Vector3 AnchorZero => _anchor.Zero;
        public Quaternion AnchorIdentity => _anchor.Identity;
    }
}
