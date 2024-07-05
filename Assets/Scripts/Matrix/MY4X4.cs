using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using customMath;

public class MY4X4 : IEquatable<MY4X4>
{
    #region Variables
    public float m00;
    public float m33;
    public float m23;
    public float m13;
    public float m03;
    public float m32;
    public float m22;
    public float m02;
    public float m12;
    public float m21;
    public float m11;
    public float m01;
    public float m30;
    public float m20;
    public float m10;
    public float m31;

    //
    // Summary:
    //     Attempts to get a rotation quaternion from this matrix.
    public Quaternion rotation { get { throw new NotImplementedException(); } }
    //
    // Summary:
    //     Attempts to get a scale value from the matrix. (Read Only)
    public Vector3 lossyScale { get { throw new NotImplementedException(); } }
    //
    // Summary:
    //     Checks whether this is an identity matrix. (Read Only)
    public bool isIdentity { get { return this == identity; } }
    //
    // Summary:
    //     The determinant of the matrix. (Read Only)
    public float determinant { get { return Determinant(this); } }
    //
    // Summary:
    //     Returns the transpose of this matrix (Read Only).
    public MY4X4 transpose { get { throw new NotImplementedException(); } }
    //
    // Summary:
    //     The inverse of this matrix. (Read Only)
    public MY4X4 inverse { get { throw new NotImplementedException(); } }
    #endregion

    #region Constructors
    public MY4X4(Vector4 column0, Vector4 column1, Vector4 column2, Vector4 column3)
    {
        m00 = column0.x;
        m10 = column0.y;
        m20 = column0.z;
        m30 = column0.w;

        m01 = column1.x;
        m11 = column1.y;
        m21 = column1.z;
        m31 = column1.w;

        m02 = column2.x;
        m12 = column2.y;
        m22 = column2.z;
        m32 = column2.w;

        m03 = column3.x;
        m13 = column3.y;
        m23 = column3.z;
        m33 = column3.w;
    }
    #endregion

    #region Constants
    public const float kEpsilon = 1E-25F;
    #endregion

    #region Defaults
    //
    // Summary:
    //     Returns a matrix with all elements set to zero (Read Only).
    public static MY4X4 zero { get { return new MY4X4(Vector4.zero, Vector4.zero, Vector4.zero, Vector4.zero); } }
    //
    // Summary:
    //     Returns the identity matrix (Read Only).
    public static MY4X4 identity
    {
        get
        {
            Vector4 col1 = new Vector4(1, 0);
            Vector4 col2 = new Vector4(0, 1);
            Vector4 col3 = new Vector4(0, 0, 1);
            Vector4 col4 = new Vector4(0, 0, 0, 1);
            return new MY4X4(col1, col2, col3, col4);
        }
    }
    #endregion

    #region Operators
    public static Vector4 operator *(MY4X4 lhs, Vector4 vector)
    {
        //each row times column (in this case always same column vector)
        float x = lhs.m00 * vector.x + lhs.m01 * vector.y + lhs.m02 * vector.z + lhs.m03 * vector.w;
        float y = lhs.m10 * vector.x + lhs.m11 * vector.y + lhs.m12 * vector.z + lhs.m13 * vector.w;
        float z = lhs.m20 * vector.x + lhs.m21 * vector.y + lhs.m22 * vector.z + lhs.m23 * vector.w;

        return new Vector4(x, y, z, vector.w);
    }
    public static MY4X4 operator *(MY4X4 lhs, MY4X4 rhs)
    {
        MY4X4 newMatrix = MY4X4.zero;
        newMatrix.m00 = lhs.m00 * rhs.m00 + lhs.m01 * rhs.m10 + lhs.m02 * rhs.m20 + lhs.m03 * rhs.m30;
        newMatrix.m01 = lhs.m00 * rhs.m01 + lhs.m01 * rhs.m11 + lhs.m02 * rhs.m21 + lhs.m03 * rhs.m31;
        newMatrix.m02 = lhs.m00 * rhs.m02 + lhs.m01 * rhs.m12 + lhs.m02 * rhs.m22 + lhs.m03 * rhs.m32;
        newMatrix.m03 = lhs.m00 * rhs.m03 + lhs.m01 * rhs.m13 + lhs.m02 * rhs.m23 + lhs.m03 * rhs.m33;

        newMatrix.m10 = lhs.m10 * rhs.m00 + lhs.m11 * rhs.m10 + lhs.m12 * rhs.m20 + lhs.m13 * rhs.m30;
        newMatrix.m11 = lhs.m10 * rhs.m01 + lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31;
        newMatrix.m12 = lhs.m10 * rhs.m02 + lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32;
        newMatrix.m13 = lhs.m10 * rhs.m03 + lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33;

        newMatrix.m20 = lhs.m20 * rhs.m00 + lhs.m21 * rhs.m10 + lhs.m22 * rhs.m20 + lhs.m23 * rhs.m30;
        newMatrix.m21 = lhs.m20 * rhs.m01 + lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31;
        newMatrix.m22 = lhs.m20 * rhs.m02 + lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32;
        newMatrix.m23 = lhs.m20 * rhs.m03 + lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33;

        newMatrix.m30 = lhs.m30 * rhs.m00 + lhs.m31 * rhs.m10 + lhs.m32 * rhs.m20 + lhs.m33 * rhs.m30;
        newMatrix.m31 = lhs.m30 * rhs.m01 + lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31;
        newMatrix.m32 = lhs.m30 * rhs.m02 + lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32;
        newMatrix.m33 = lhs.m30 * rhs.m03 + lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33;

        return newMatrix;
    }
    public static bool operator ==(MY4X4 lhs, MY4X4 rhs)
    {
        float diff_m00 = lhs.m00 - rhs.m00;
        float diff_m01 = lhs.m01 - rhs.m01;
        float diff_m02 = lhs.m02 - rhs.m02;
        float diff_m03 = lhs.m03 - rhs.m03;

        float sqrRow0 = diff_m00 * diff_m00 + diff_m01 * diff_m01 + diff_m02 * diff_m02 + diff_m03 * diff_m03;

        float diff_m10 = lhs.m10 - rhs.m10;
        float diff_m11 = lhs.m11 - rhs.m11;
        float diff_m12 = lhs.m12 - rhs.m12;
        float diff_m13 = lhs.m13 - rhs.m13;
        float sqrRow1 = diff_m10 * diff_m10 + diff_m11 * diff_m11 + diff_m12 * diff_m12 + diff_m13 * diff_m13;

        float diff_m20 = lhs.m20 - rhs.m20;
        float diff_m21 = lhs.m21 - rhs.m21;
        float diff_m22 = lhs.m22 - rhs.m22;
        float diff_m23 = lhs.m23 - rhs.m23;
        float sqrRow2 = diff_m20 * diff_m20 + diff_m21 * diff_m21 + diff_m22 * diff_m22 + diff_m23 * diff_m23;

        float diff_m30 = lhs.m30 - rhs.m30;
        float diff_m31 = lhs.m31 - rhs.m31;
        float diff_m32 = lhs.m32 - rhs.m32;
        float diff_m33 = lhs.m33 - rhs.m33;
        float sqrRow3 = diff_m30 * diff_m30 + diff_m31 * diff_m31 + diff_m32 * diff_m32 + diff_m33 * diff_m33;

        float squares = sqrRow0 + sqrRow1 + sqrRow2 + sqrRow3;
        return squares < kEpsilon * kEpsilon;
        //Checks if the difference between both vectors is close to zero
        // return sqrmag < kEpsilon * kEpsilon;
    }
    public static bool operator !=(MY4X4 lhs, MY4X4 rhs)
    {
        return !(lhs == rhs);
    }
    #endregion

    #region Functions
    public static float Determinant(MY4X4 m)
    {
        float a = m.m00;
        float b = m.m01;
        float c = m.m02;
        float d = m.m03;

        //m00 m01 m02 m03
        //m10 m11 m12 m13
        //m20 m21 m22 m23
        //m30 m31 m32 m33

        // aDeterminant 
        // m11 m12 m13
        // m21 m22 m23
        // m31 m32 m33
        float aDeterminant = m.m11 * (m.m22 * m.m33 - m.m23 * m.m32) - m.m12 * (m.m21 * m.m33 - m.m23 * m.m31) + m.m13 * (m.m21 * m.m32 - m.m22 * m.m31);

        // bDeterminant 
        // m10 m12 m13
        // m20 m22 m23
        // m30 m32 m33
        float bDeterminant = m.m10 * (m.m22 * m.m33 - m.m23 * m.m32) - m.m12 * (m.m20 * m.m33 - m.m23 * m.m30) + m.m13 * (m.m20 * m.m32 - m.m22 * m.m30);

        // cDeterminant 
        // m10 m11 m13
        // m20 m21 m23
        // m30 m31 m33
        float cDeterminant = m.m10 * (m.m21 * m.m33 - m.m23 * m.m31) - m.m11 * (m.m20 * m.m33 - m.m23 * m.m30) + m.m13 * (m.m20 * m.m31 - m.m21 * m.m30);
        // dDeterminant 
        // m10 m11 m12
        // m20 m21 m22
        // m30 m31 m32
        float dDeterminant = m.m10 * (m.m21 * m.m32 - m.m22 * m.m31) - m.m11 * (m.m20 * m.m32 - m.m22 * m.m30) + m.m12 * (m.m20 * m.m31 - m.m21 * m.m30);

        return a * aDeterminant - b * bDeterminant + c * cDeterminant - d * dDeterminant;
    }
    public static MY4X4 Inverse(MY4X4 m)
    {
        throw new NotImplementedException();
    }
    //
    // Summary:
    //     Create a "look at" matrix.
    //
    // Parameters:
    //   from:
    //     The source point.
    //
    //   to:
    //     The target point.
    //
    //   up:
    //     The vector describing the up direction (typically Vector3.up).
    //
    // Returns:
    //     The resulting transformation matrix.
    public static MY4X4 LookAt(Vector3 from, Vector3 to, Vector3 up)
    {

        throw new NotImplementedException();
    }
    //
    // Summary:
    //     Creates a rotation matrix.
    //
    // Parameters:
    //   q:
    public static MY4X4 Rotate(MyQuaternion q)
    {
        MyQuaternion rotation = q;
        rotation.Normalize();

        Vector4 firstColumn = new Vector4(2 * (rotation.w * rotation.w + rotation.x * rotation.x) - 1,
                                          2 * (rotation.x * rotation.y + rotation.w * rotation.z),
                                          2 * (rotation.x * rotation.z - rotation.w * rotation.y),
                                          0);

        Vector4 secondColumn = new Vector4(2 * (rotation.x * rotation.y - rotation.w * rotation.z),
                                           2 * (rotation.w * rotation.w + rotation.y * rotation.y) - 1,
                                           2 * (rotation.y * rotation.z + rotation.w * rotation.x),
                                           0);

        Vector4 thirdColumn = new Vector4(2 * (rotation.x * rotation.z + rotation.w * rotation.y),
                                          2 * (rotation.y * rotation.z - rotation.w * rotation.x),
                                          2 * (rotation.w * rotation.w + rotation.z * rotation.z) - 1,
                                          0);

        Vector4 fourthColumn = new Vector4(0, 0, 0, 1);

        return new MY4X4(firstColumn, secondColumn, thirdColumn, fourthColumn);
    }
    //
    // Summary:
    //     Creates a scaling matrix.
    //
    // Parameters:
    //   vector:
    public static MY4X4 Scale(Vector3 vector)
    {
        Vector4 col1 = new Vector4(vector.x, 0);
        Vector4 col2 = new Vector4(0, vector.y);
        Vector4 col3 = new Vector4(0, 0, vector.z);
        Vector4 col4 = new Vector4(0, 0, 0, 1);
        return new MY4X4(col1, col2, col3, col4);
    }
    //
    // Summary:
    //     Creates a translation matrix.
    //
    // Parameters:
    //   vector:
    public static MY4X4 Translate(Vector3 vector)
    {
        Vector4 col1 = new Vector4(1, 0);
        Vector4 col2 = new Vector4(0, 1);
        Vector4 col3 = new Vector4(0, 0, 1);
        Vector4 col4 = new Vector4(vector.x, vector.y, vector.z, 1);
        return new MY4X4(col1, col2, col3, col4);
    }
    public static MY4X4 Transpose(MY4X4 m)
    {

        throw new NotImplementedException();
    }
    //
    // Summary:
    //     Creates a translation, rotation and scaling matrix.
    //
    // Parameters:
    //   pos:
    //
    //   q:
    //
    //   s:
    public static MY4X4 TRS(Vector3 pos, MyQuaternion q, Vector3 s)
    {
        return Translate(pos) * Rotate(q) * Scale(s);
    }
    //
    // Summary:
    //     Get a column of the matrix.
    //
    // Parameters:
    //   index:
    public Vector4 GetColumn(int index)
    {
        switch (index)
        {
            case 0:
                return new Vector4(m00, m10, m20, m30);
            case 1:
                return new Vector4(m01, m11, m21, m31);
            case 2:
                return new Vector4(m02, m12, m22, m32);
            case 3:
                return new Vector4(m03, m13, m23, m33);
            default:
                throw new Exception("Invalid Index");
        }
    }
    //
    // Summary:
    //     Get position vector from the matrix.
    public Vector3 GetPosition()
    {

        throw new NotImplementedException();
    }
    //
    // Summary:
    //     Returns a row of the matrix.
    //
    // Parameters:
    //   index:
    public Vector4 GetRow(int index)
    {
        switch (index)
        {
            case 0:
                return new Vector4(m00, m01, m02, m03);
            case 1:
                return new Vector4(m10, m11, m12, m13);
            case 2:
                return new Vector4(m20, m21, m22, m23);
            case 3:
                return new Vector4(m30, m31, m32, m33);
            default:
                throw new Exception("Invalid Index");
        }
    }
    //
    // Summary:
    //     Transforms a position by this matrix (generic).
    //
    // Parameters:
    //   point:
    public Vector3 MultiplyPoint(Vector3 point)
    {

        throw new NotImplementedException();
    }
    //
    // Summary:
    //     Transforms a position by this matrix (fast).
    //
    // Parameters:
    //   point:
    public Vector3 MultiplyPoint3x4(Vector3 point)
    {

        throw new NotImplementedException();
    }
    //
    // Summary:
    //     Transforms a direction by this matrix.
    //
    // Parameters:
    //   vector:
    public Vector3 MultiplyVector(Vector3 vector)
    {

        throw new NotImplementedException();
    }
    //
    // Summary:
    //     Sets a column of the matrix.
    //
    // Parameters:
    //   index:
    //
    //   column:
    public void SetColumn(int index, Vector4 column)
    {

        throw new NotImplementedException();
    }
    //
    // Summary:
    //     Sets a row of the matrix.
    //
    // Parameters:
    //   index:
    //
    //   row:
    public void SetRow(int index, Vector4 row)
    {

        throw new NotImplementedException();
    }
    //
    // Summary:
    //     Sets this matrix to a translation, rotation and scaling matrix.
    //
    // Parameters:
    //   pos:
    //
    //   q:
    //
    //   s:
    public void SetTRS(Vector3 pos, Quaternion q, Vector3 s)
    {

        throw new NotImplementedException();
    }
    //
    // Summary:
    //     Returns a formatted string for this matrix.
    //
    // Parameters:
    //   format:
    //     A numeric format string.
    //
    //   formatProvider:
    //     An object that specifies culture-specific formatting.

    //
    // Summary:
    //     Checks if this matrix is a valid transform matrix.
    public bool ValidTRS()
    {

        throw new NotImplementedException();
    }

    #endregion

    #region Internals
    public override string ToString()
    {
        return $"{m00}\t {m01}\t {m02}\t {m03}\n" +
               $"{m10}\t {m11}\t {m12}\t {m13}\n" +
               $"{m20}\t {m21}\t {m22}\t {m23}\n" +
               $"{m30}\t {m31}\t {m32}\t {m33}";
    }

    public float this[int index] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
    public float this[int row, int column] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

    public override bool Equals(object other)
    {
        throw new NotImplementedException();
    }
    public bool Equals(MY4X4 other)
    {
        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {

        throw new NotImplementedException();
    }


    #endregion
}
