using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace Ldm.Relocator
{
    public class TriangleBasedRelocator : MonoBehaviour
    {
        [SerializeField] private List<TriangleBasedRelocatable> _relocatablesLibrary;
        //we store all the instances we spawn so we don't spawn the same prefab twice
        private Dictionary<Triangle3D, GameObject> _instances = new();

        public void SpawnFittingRelocatable(Vector3 triangleVertex1, Vector3 triangleVertex2, Vector3 triangleVertex3, float errorMargin)
        {
            SpawnFittingRelocatable(new Triangle3D { A = triangleVertex1, B = triangleVertex2, C = triangleVertex3 }, errorMargin);
        }
        public void SpawnFittingRelocatable(Triangle3D triangleFromWorld, float errorMargin)
        {
            var enrichedTriangle = new EnrichedTriangle(triangleFromWorld);
            if (TryFindFittingRelocatable(enrichedTriangle, out var foundItem))
            {
                var prefabToSpawn = foundItem.ObjectToRelocate;
                var refTriangle = new EnrichedTriangle(foundItem.Triangle);
                //calculate the "local" Pose of prefabtospawn compared to its triangle
                var localPose = PoseTools.WorldPoseToLocalPose(new Pose(prefabToSpawn.transform.position, prefabToSpawn.transform.rotation), refTriangle.Zero, refTriangle.Identity);
                //then we transform this "local" pose into a new world pose, this time using the triangle we meazured as reference point
                var newWorldPose = PoseTools.LocalPoseToWorldPose(localPose, enrichedTriangle.Zero, enrichedTriangle.Identity);
                //get or instantiate the "object to relocate"

                if (!_instances.TryGetValue(foundItem.Triangle, out var instanceToRelocate))
                {
                    instanceToRelocate = Instantiate(prefabToSpawn);
                    _instances[foundItem.Triangle] = instanceToRelocate;
                }
                //move to the calculated Pose


                instanceToRelocate.transform.position = newWorldPose.position;
                instanceToRelocate.transform.rotation = newWorldPose.rotation;
            }
        }

        private bool TryFindFittingRelocatable(EnrichedTriangle triangle, out TriangleBasedRelocatable foundItem)
        {
            foundItem = _relocatablesLibrary?.FirstOrDefault(s =>
            {
                var enriched = new EnrichedTriangle(s.Triangle);
                return
                (
                    Mathf.Abs(enriched.ShortSideLength - triangle.ShortSideLength) <= s.ErrorMargin
                    && Mathf.Abs(enriched.MidSideLength - triangle.MidSideLength) <= s.ErrorMargin
                    && Mathf.Abs(enriched.LongSideLength - triangle.LongSideLength) <= s.ErrorMargin
                );
            });

            return foundItem != null;
        }
    }
}