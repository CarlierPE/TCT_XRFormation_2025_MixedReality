using UnityEngine;

namespace Ldm.Relocator
{
    public class AnchorBasedRelocator : MonoBehaviour
    {
        [SerializeField] AnchorBasedRelocatable _prefabToRelocate;
        AnchorBasedRelocatable _instanceToRelocate;

        public void Relocate(Pose poseToRelocateTo)
        {
            if(_instanceToRelocate == null)
            {
                if (_prefabToRelocate.gameObject.scene.IsValid() && _prefabToRelocate.gameObject.scene.isLoaded)
                    _instanceToRelocate = _prefabToRelocate;
                else
                    _instanceToRelocate = Instantiate(_prefabToRelocate);
            }


            var localPose = PoseTools.WorldPoseToLocalPose(new Pose(_instanceToRelocate.transform.position, _instanceToRelocate.transform.rotation), _instanceToRelocate.AnchorZero, _instanceToRelocate.AnchorIdentity);
            var newWorldPose = PoseTools.LocalPoseToWorldPose(localPose, poseToRelocateTo.position, poseToRelocateTo.rotation);

            _instanceToRelocate.transform.position = newWorldPose.position;
            _instanceToRelocate.transform.rotation = newWorldPose.rotation;
        }
    }
}