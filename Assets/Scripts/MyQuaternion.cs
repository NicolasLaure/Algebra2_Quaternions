using System;
using UnityEngine;

namespace customMath
{
    public class MyQuaternion : IEquatable<MyQuaternion>
    {
        #region Variables
        public float x;
        public float y;
        public float z;
        public float w;

        public float this[int index] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public Vector3 eulerAngles { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public MyQuaternion normalized { get { throw new NotImplementedException(); } }
        #endregion

        #region Constants
        public const float kEpsilon = 1E-06F;
        #endregion

        #region DefaultValues
        public static MyQuaternion identity { get { throw new NotImplementedException(); } }
        #endregion

        #region Constructors
        public MyQuaternion(float x, float y, float z, float w)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Operators
        public static Vector3 operator *(MyQuaternion rotation, Vector3 point)
        {
            throw new NotImplementedException();
        }
        public static MyQuaternion operator *(MyQuaternion lhs, MyQuaternion rhs)
        {
            throw new NotImplementedException();
        }
        public static bool operator ==(MyQuaternion lhs, MyQuaternion rhs)
        {
            throw new NotImplementedException();
        }
        public static bool operator !=(MyQuaternion lhs, MyQuaternion rhs)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Functions
        public static float Angle(MyQuaternion a, MyQuaternion b)
        {
            throw new NotImplementedException();
        }
        public static MyQuaternion AngleAxis(float angle, Vector3 axis)
        {
            throw new NotImplementedException();
        }
        public static float Dot(MyQuaternion a, MyQuaternion b)
        {
            throw new NotImplementedException();
        }
        public static MyQuaternion Euler(Vector3 euler)
        {
            throw new NotImplementedException();
        }
        public static MyQuaternion Euler(float x, float y, float z)
        {
            throw new NotImplementedException();
        }
        public static MyQuaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection)
        {
            throw new NotImplementedException();
        }
        public static MyQuaternion Inverse(MyQuaternion rotation)
        {
            throw new NotImplementedException();
        }
        public static MyQuaternion Lerp(MyQuaternion a, MyQuaternion b, float t)
        {
            throw new NotImplementedException();
        }
        public static MyQuaternion LerpUnclamped(MyQuaternion a, MyQuaternion b, float t)
        {
            throw new NotImplementedException();
        }
        public static MyQuaternion LookRotation(Vector3 forward)
        {
            throw new NotImplementedException();
        }
        public static MyQuaternion LookRotation(Vector3 forward, [UnityEngine.Internal.DefaultValue("Vector3.up")] Vector3 upwards)
        {
            throw new NotImplementedException();
        }
        public static MyQuaternion Normalize(MyQuaternion q)
        {
            throw new NotImplementedException();
        }
        public static MyQuaternion RotateTowards(MyQuaternion from, MyQuaternion to, float maxDegreesDelta)
        {
            throw new NotImplementedException();
        }
        public static MyQuaternion Slerp(MyQuaternion a, MyQuaternion b, float t)
        {
            throw new NotImplementedException();
        }
        public static MyQuaternion SlerpUnclamped(MyQuaternion a, MyQuaternion b, float t)
        {
            throw new NotImplementedException();
        }
        public void Normalize()
        {
            throw new NotImplementedException();
        }
        public void SetEulerRotation(Vector3 euler)
        {
            throw new NotImplementedException();
        }
        public void SetFromToRotation(Vector3 fromDirection, Vector3 toDirection)
        {
            throw new NotImplementedException();
        }
        public void SetLookRotation(Vector3 view)
        {
            throw new NotImplementedException();
        }
        public void SetLookRotation(Vector3 view, [UnityEngine.Internal.DefaultValue("Vector3.up")] Vector3 up)
        {
            throw new NotImplementedException();
        }
        public void ToAngleAxis(out float angle, out Vector3 axis)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Internals
        public bool Equals(MyQuaternion other)
        {
            return x == other.x && y == other.y && z == other.z && w == other.w;
        }
        public override bool Equals(object other)
        {
            if (!(other is MyQuaternion)) return false;
            return Equals((MyQuaternion)other);
        }
        #endregion
    }
}