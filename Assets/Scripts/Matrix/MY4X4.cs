using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public bool isIdentity { get { throw new NotImplementedException(); } }
    //
    // Summary:
    //     The determinant of the matrix. (Read Only)
    public float determinant { get { throw new NotImplementedException(); } }
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

        throw new NotImplementedException();
    }
    public static MY4X4 operator *(MY4X4 lhs, MY4X4 rhs)
    {

        throw new NotImplementedException();
    }
    public static bool operator ==(MY4X4 lhs, MY4X4 rhs)
    {

        throw new NotImplementedException();
    }
    public static bool operator !=(MY4X4 lhs, MY4X4 rhs)
    {

        throw new NotImplementedException();
    }
    #endregion

    #region Functions
    public static float Determinant(MY4X4 m)
    {
        throw new NotImplementedException();
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
    public static MY4X4 Rotate(Quaternion q)
    {

        throw new NotImplementedException();
    }
    //
    // Summary:
    //     Creates a scaling matrix.
    //
    // Parameters:
    //   vector:
    public static MY4X4 Scale(Vector3 vector)
    {

        throw new NotImplementedException();
    }
    //
    // Summary:
    //     Creates a translation matrix.
    //
    // Parameters:
    //   vector:
    public static MY4X4 Translate(Vector3 vector)
    {

        throw new NotImplementedException();
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
    public static MY4X4 TRS(Vector3 pos, Quaternion q, Vector3 s)
    {

        throw new NotImplementedException();
    }
    //
    // Summary:
    //     Get a column of the matrix.
    //
    // Parameters:
    //   index:
    public Vector4 GetColumn(int index)
    {

        throw new NotImplementedException();
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

        throw new NotImplementedException();
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
        return $"{m00} {m01} {m02} {m03}\n" +
               $"{m10} {m11} {m12} {m13}\n" +
               $"{m20} {m21} {m22} {m23}\n" +
               $"{m30} {m31} {m32} {m33}";
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
