using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ldm.Relocator
{
    public class EnrichedTriangle
    {
        public EnrichedTriangle(Triangle3D triangle)
        {
            _triangle = triangle;

            var ab = new Side(_triangle.A, _triangle.B);
            var bc = new Side(_triangle.B, _triangle.C);
            var ca = new Side(_triangle.C, _triangle.A);

            var allSides = new Side[3] { ab, bc, ca }.OrderByDescending(s=>s.Length).ToArray();
            
            var longSide = allSides[0];

            _zero = new Vector3[3] { _triangle.A, _triangle.B, _triangle.C }.Except(new Vector3[2] { longSide.A, longSide.B }).First();
            //not using shortSide and midSide directly because we want the orientation of the vectors to be consistant
            //so we always end up with the same "Up" vector for a given triangle
            var calcVector1 = longSide.A - _zero;
            var calcVector2 = longSide.B - _zero;
            Vector3 shortVector;
            Vector3 midVector;
            if(calcVector1.magnitude < calcVector2.magnitude)
            {
                shortVector = calcVector1;
                midVector = calcVector2;
            }
            else
            {
                shortVector = calcVector2;
                midVector = calcVector1;
            }
            //the order of arguments in the cross product matters, otherwise we could have a 180°
            //rotation of the up vector depending on in which order the triangle was drawn
            _up = Vector3.Cross(shortVector, midVector).normalized;
            _right = shortVector.normalized;
            _forward = Vector3.Cross(_up, _right).normalized;
            _identity = Quaternion.LookRotation(_forward, _up);
            _longSideLength = longSide.Length;
            _midSideLength = allSides[1].Length;
            _shortSideLength = allSides[2].Length;
        }
        public Triangle3D Triangle => _triangle;
        private Triangle3D _triangle;

        public Vector3 Zero => _zero;
        private Vector3 _zero;

        public Vector3 Up => _up;
        private Vector3 _up;

        public Vector3 Right => _right;
        private Vector3 _right;

        public Vector3 Forward => _forward;
        private Vector3 _forward;

        public Quaternion Identity => _identity;
        private Quaternion _identity;

        public float ShortSideLength => _shortSideLength;
        private float _shortSideLength;

        public float MidSideLength => _midSideLength;
        private float _midSideLength;

        public float LongSideLength => _longSideLength;
        private float _longSideLength;

        private class Side
        {
            Vector3 _vertexA;
            Vector3 _vertexB;

            public Vector3 A => _vertexA;
            public Vector3 B => _vertexB;

            public Side(Vector3 a, Vector3 b)
            {
                _vertexA = a;
                _vertexB = b;
            }
            public float Length => (_vertexB - _vertexA).magnitude;
        }
    }
}