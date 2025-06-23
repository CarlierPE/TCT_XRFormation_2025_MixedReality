using System;
using UnityEngine;

namespace Ldm.Relocator
{
    [System.Serializable]
    public struct Triangle3D : IEquatable<Triangle3D>
    {
        public Vector3 A, B, C;

        public bool Equals(Triangle3D other)
        {
            return A == other.A && B == other.B && C == other.C;
        }

        public override bool Equals(object obj)
        {
            return obj is Triangle3D other && Equals(other);
        }

        public override int GetHashCode()
        {
            return A.GetHashCode() ^ B.GetHashCode() ^ C.GetHashCode();
        }
    }
}
