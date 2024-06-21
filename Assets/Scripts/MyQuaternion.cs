using System;
using UnityEngine;

namespace customMath
{
    [Serializable]
    public class MyQuaternion : IEquatable<MyQuaternion>, IFormattable
    {
        #region Variables
        public float x;
        public float y;
        public float z;
        public float w;

        public Vector3 eulerAngles
        {
            get
            {
                // pointer to Cuaterniones_y_unity.pptm.pdf page 9-14

                float xValue = x * w - y * z;
                Vector3 result = Vector3.zero;

                if (xValue > 0.4999f * sqrMagnitude)
                {
                    result.y = 2f * Mathf.Atan2(y, x);
                    result.x = Mathf.PI / 2;
                    result.z = 0;
                    return result * Mathf.Rad2Deg;
                }
                if (xValue < -0.4999f * sqrMagnitude)
                {
                    result.y = -2f * Mathf.Atan2(y, x);
                    result.x = -Mathf.PI / 2;
                    result.z = 0;
                    return result * Mathf.Rad2Deg;
                }

                MyQuaternion quaternion = new MyQuaternion(w, z, x, y);
                result.y = Mathf.Atan2(2f * quaternion.x * quaternion.w + 2f * quaternion.y * quaternion.z, 1f - 2f * (quaternion.z * quaternion.z + quaternion.w * quaternion.w));
                result.x = Mathf.Asin(2f * (quaternion.x * quaternion.z - quaternion.w * quaternion.y));
                result.z = Mathf.Atan2(2f * quaternion.x * quaternion.y + 2f * quaternion.z * quaternion.w, 1f - 2f * (quaternion.y * quaternion.y + quaternion.z * quaternion.z));
                return result * Mathf.Rad2Deg;
            }
            set
            {
                MyQuaternion q = Euler(value);
                this.Set(q.x, q.y, q.z, q.w);
            }
        }
        public float sqrMagnitude { get { return w * w + x * x + y * y + z * z; } }
        public float magnitude { get { return MathF.Sqrt(sqrMagnitude); } }
        public MyQuaternion normalized { get { return new MyQuaternion(x / magnitude, y / magnitude, z / magnitude, w / magnitude); } }
        public Quaternion toQuaternion { get { return new Quaternion(x, y, z, w); } set { x = value.x; y = value.y; z = value.z; w = value.w; } }
        #endregion

        #region Constants
        public const float kEpsilon = 1E-06F;
        #endregion

        #region DefaultValues
        public static MyQuaternion identity { get { return new MyQuaternion(0, 0, 0, 1); } }
        #endregion

        #region Constructors
        public MyQuaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        #endregion

        #region Operators
        public static Vector3 operator *(MyQuaternion rotation, Vector3 point)
        {
            Vector4 firstColumn = new Vector4(2 * (rotation.w * rotation.w + rotation.x * rotation.x) - 1,
                                              2 * (rotation.x * rotation.y + rotation.w * rotation.z),
                                              2 * (rotation.x * rotation.z - rotation.w * rotation.y), 0);

            Vector4 secondColumn = new Vector4(2 * (rotation.x * rotation.y - rotation.w * rotation.z),
                                               2 * (rotation.w * rotation.w + rotation.y * rotation.y) - 1,
                                               2 * (rotation.y * rotation.z + rotation.w * rotation.x), 0);

            Vector4 thirdColumn = new Vector4(2 * (rotation.x * rotation.z + rotation.w * rotation.y),
                                              2 * (rotation.y * rotation.z - rotation.w * rotation.x),
                                              2 * (rotation.w * rotation.w + rotation.z * rotation.z) - 1, 0);

            Vector4 fourthColumn = new Vector4(0, 0, 0, 1);

            Matrix4x4 myRotationMatrix = new Matrix4x4(firstColumn, secondColumn, thirdColumn, fourthColumn);
            Vector4 pointV4 = new Vector4(point.x, point.y, point.z, 1);

            Vector4 result = myRotationMatrix * pointV4;
            return new Vector3(result.x, result.y, result.z);
        }
        public static MyQuaternion operator *(MyQuaternion lhs, MyQuaternion rhs)
        {
            // https://stackoverflow.com/questions/19956555/how-to-multiply-two-quaternions
            //i^2 = -1
            //i^3 = -i
            //i^4 = 1

            //    mul reales| x1i*x2i  |  y1j*y2j  | z1k* z2k
            //    a.w* b.w - a.x * b.x - a.y * b.y - a.z * b.z,  // 1

            //    a.w* b.x + a.x * b.w + a.y * b.z - a.z * b.y,  // i
            //    a.w* b.y - a.x * b.z + a.y * b.w + a.z * b.x,  // j
            //    a.w* b.z + a.x * b.y - a.y * b.x + a.z * b.w   // k

            // rearrange it to fit into my format x y z w in this case i j k 1
            return new MyQuaternion(
                                    lhs.w * rhs.x + lhs.x * rhs.w + lhs.y * rhs.z - lhs.z * rhs.y,
                                    lhs.w * rhs.y - lhs.x * rhs.z + lhs.y * rhs.w + lhs.z * rhs.x,
                                    lhs.w * rhs.z + lhs.x * rhs.y - lhs.y * rhs.x + lhs.z * rhs.w,
                                    lhs.w * rhs.w - lhs.x * rhs.x - lhs.y * rhs.y - lhs.z * rhs.z);
        }
        public static bool operator ==(MyQuaternion lhs, MyQuaternion rhs)
        {
            float diff_x = lhs.x - rhs.x;
            float diff_y = lhs.y - rhs.y;
            float diff_z = lhs.z - rhs.z;
            float diff_w = lhs.w - rhs.w;
            float sqrmag = diff_x * diff_x + diff_y * diff_y + diff_z * diff_z + diff_w * diff_w;
            //Checks if the difference between both vectors is close to zero
            return sqrmag < kEpsilon * kEpsilon;
        }
        public static bool operator !=(MyQuaternion lhs, MyQuaternion rhs)
        {
            return !(lhs == rhs);
        }
        #endregion

        #region Functions
        public static float Angle(MyQuaternion a, MyQuaternion b)
        {
            //  Pointer to Cuaterniones_y_unity.pptm.pdf Page 15
            float dotAbs = Mathf.Abs(Dot(a, b));
            return a == b ? 0.0f : Mathf.Acos(Mathf.Min(dotAbs, 1.0f)) * 2 * Mathf.Rad2Deg;
        }
        public static MyQuaternion AngleAxis(float angle, Vector3 axis)
        {
            axis.Normalize();
            // we divide the angle by the amount of axis we operate minus one because the angle gets distributed through all the axis we operate
            // this distribution takes place so the scalar is the amount of axis we can rotate around minus 1, making a 1D rotation not work by trying to divide by 0
            // 2D has the angle divided by 1 so it can be simplified
            // 3D has the angle divided by 2
            axis *= Mathf.Sin(angle * Mathf.Deg2Rad * 0.5f);
            return new MyQuaternion(axis.x, axis.y, axis.z, Mathf.Cos(angle * Mathf.Deg2Rad * 0.5f));
        }
        public static float Dot(MyQuaternion a, MyQuaternion b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }
        public static MyQuaternion Euler(Vector3 euler)
        {

            // pointer to Cuaterniones_y_unity.pptm.pdf page 8
            MyQuaternion qx = identity;
            MyQuaternion qy = identity;
            MyQuaternion qz = identity;

            float halfAngleToRadians = Mathf.Deg2Rad * 0.5f;
            qz.Set(0, 0, MathF.Sin(euler.z * halfAngleToRadians), MathF.Cos(euler.z * halfAngleToRadians));
            qx.Set(MathF.Sin(euler.x * halfAngleToRadians), 0, 0, MathF.Cos(euler.x * halfAngleToRadians));
            qy.Set(0, MathF.Sin(euler.y * halfAngleToRadians), 0, MathF.Cos(euler.y * halfAngleToRadians));

            return qy * qx * qz;
        }
        public static MyQuaternion Euler(float x, float y, float z)
        {
            MyQuaternion qx = identity;
            MyQuaternion qy = identity;
            MyQuaternion qz = identity;

            float halfAngleToRadians = Mathf.Deg2Rad * 0.5f;
            qz.Set(0, 0, MathF.Sin(z * halfAngleToRadians), MathF.Cos(z * halfAngleToRadians));
            qx.Set(MathF.Sin(x * halfAngleToRadians), 0, 0, MathF.Cos(x * halfAngleToRadians));
            qy.Set(0, MathF.Sin(y * halfAngleToRadians), 0, MathF.Cos(y * halfAngleToRadians));

            return qy * qx * qz;
        }
        public static MyQuaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection)
        {
            //Creates the axis based on the perpendicular vector to both (We'll rotate around it)
            Vector3 axis = Vector3.Cross(fromDirection, toDirection);
            //Gets the angle between the vectors
            float angle = Vector3.Angle(fromDirection, toDirection);
            //Returns the rotation in angles around the previously calculated axis
            return AngleAxis(angle, axis.normalized);
        }
        public static MyQuaternion Inverse(MyQuaternion rotation)
        {
            return new MyQuaternion(-rotation.x, -rotation.y, -rotation.z, rotation.w);
        }
        public static MyQuaternion Lerp(MyQuaternion a, MyQuaternion b, float t)
        {
            MyQuaternion result = identity;
            t = Mathf.Clamp01(t);
            float timeLeft = 1 - t;
            if (Dot(a, b) >= 0)
            {
                result.x = (timeLeft * a.x) + (t * b.x);
                result.y = (timeLeft * a.y) + (t * b.y);
                result.z = (timeLeft * a.z) + (t * b.z);
                result.w = (timeLeft * a.w) + (t * b.w);
            }
            else
            {
                result.x = (timeLeft * a.x) - (t * b.x);
                result.y = (timeLeft * a.y) - (t * b.y);
                result.z = (timeLeft * a.z) - (t * b.z);
                result.w = (timeLeft * a.w) - (t * b.w);
            }
            result.Normalize();
            return result;
        }
        public static MyQuaternion LerpUnclamped(MyQuaternion a, MyQuaternion b, float t)
        {
            MyQuaternion result = identity;

            float timeLeft = 1 - t;
            if (Dot(a, b) >= 0)
            {
                result.x = (timeLeft * a.x) + (t * b.x);
                result.y = (timeLeft * a.y) + (t * b.y);
                result.z = (timeLeft * a.z) + (t * b.z);
                result.w = (timeLeft * a.w) + (t * b.w);
            }
            else
            {
                result.x = (timeLeft * a.x) - (t * b.x);
                result.y = (timeLeft * a.y) - (t * b.y);
                result.z = (timeLeft * a.z) - (t * b.z);
                result.w = (timeLeft * a.w) - (t * b.w);
            }
            result.Normalize();
            return result;
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
            return new MyQuaternion(q.x / q.magnitude, q.y / q.magnitude, q.z / q.magnitude, q.w / q.magnitude);
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
            float originalMagnitude = magnitude;

            x /= originalMagnitude;
            y /= originalMagnitude;
            z /= originalMagnitude;
            w /= originalMagnitude;
        }

        public void Set(float newX, float newY, float newZ, float newW)
        {
            x = newX;
            y = newY;
            z = newZ;
            w = newW;
        }
        public void SetFromToRotation(Vector3 fromDirection, Vector3 toDirection)
        {
            Vector3 axis = Vector3.Cross(fromDirection, toDirection);
            float angle = Vector3.Angle(fromDirection, toDirection);
            MyQuaternion result = AngleAxis(angle, axis.normalized);
            x = result.x;
            y = result.y;
            z = result.z;
            w = result.w;
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
            Normalize();
            angle = 2.0f * Mathf.Acos(w) * Mathf.Rad2Deg;
            float mag = Mathf.Sqrt(1.0f - w * w);
            if (mag > 0.0001f)
            {
                axis = new Vector3(x, y, z) / mag;
            }
            else
            {
                axis = new Vector3(1, 0, 0);
            }
        }
        #endregion

        #region Internals
        public float this[int index]
        {
            get
            {
                float[] values = { x, y, z, w };
                return values[index];
            }
            set
            {
                float[] values = { x, y, z, w };
                values[index] = value;

                this.x = values[0];
                this.y = values[1];
                this.z = values[2];
                this.w = values[3];
            }
        }
        public bool Equals(MyQuaternion other)
        {
            return x == other.x && y == other.y && z == other.z && w == other.w;
        }
        public override bool Equals(object other)
        {
            if (!(other is MyQuaternion)) return false;
            return Equals((MyQuaternion)other);
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{x}, {y}, {z}, {w}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, z, w, eulerAngles, normalized);
        }
        #endregion
    }
}