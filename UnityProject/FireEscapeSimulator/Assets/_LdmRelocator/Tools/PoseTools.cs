using UnityEngine;

namespace Ldm.Relocator
{
    public static class PoseTools
    {
        /// <summary>
        /// Converts a world pose into a local pose
        /// </summary>
        /// <param name="worldPose">the world pose to convert</param>
        /// <param name="zero">the zero (in world coordinates) of the item we want the local pose to</param>
        /// <param name="identity">the world rotation of the item we want the local pose to</param>
        /// <returns></returns>
        public static Pose WorldPoseToLocalPose(Pose worldPose, Vector3 zero, Quaternion identity)
        {
            Vector3 zeroedPosition = worldPose.position - zero;
            var newPos = Quaternion.Inverse(identity) * zeroedPosition;
            var newRot = Quaternion.Inverse(identity) * worldPose.rotation;
            return new Pose(newPos, newRot);
        }

        /// <summary>
        /// Converts a local pose into a world pose
        /// </summary>
        /// <param name="localPose">the local pose to convert</param>
        /// <param name="zero">the world coordinates of the transform we're local to</param>
        /// <param name="identity">the world rotation of the transform we're local to</param>
        /// <returns></returns>
        public static Pose LocalPoseToWorldPose(Pose localPose, Vector3 zero, Quaternion identity)
        {
            var rotatedPoint = identity * localPose.position;
            var newPos = rotatedPoint + zero;
            var newRot = identity * localPose.rotation;
            return new Pose(newPos, newRot);
        }

    }

}
