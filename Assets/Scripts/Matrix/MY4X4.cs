using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

public class MY4X4 : IEquatable<MY4X4>, IFormattable
{
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

    public MY4X4(Vector4 column0, Vector4 column1, Vector4 column2, Vector4 column3) { }

    public float this[int index] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
    public float this[int row, int column] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

    //
    // Summary:
    //     Returns a matrix with all elements set to zero (Read Only).
    public static MY4X4 zero { get { throw new NotImplementedException(); } }
    //
    // Summary:
    //     Returns the identity matrix (Read Only).
    public static MY4X4 identity { get { throw new NotImplementedException(); } }
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
    //     This property takes a projection matrix and returns the six plane coordinates
    //     that define a projection frustum.
    public FrustumPlanes decomposeProjection { get { throw new NotImplementedException(); } }
    //
    // Summary:
    //     The inverse of this matrix. (Read Only)
    public MY4X4 inverse { get { throw new NotImplementedException(); } }

    public static float Determinant(MY4X4 m)
    {
        throw new NotImplementedException();
    }
    //
    // Summary:
    //     This function returns a projection matrix with viewing frustum that has a near
    //     plane defined by the coordinates that were passed in.
    //
    // Parameters:
    //   left:
    //     The X coordinate of the left side of the near projection plane in view space.
    //
    //   right:
    //     The X coordinate of the right side of the near projection plane in view space.
    //
    //   bottom:
    //     The Y coordinate of the bottom side of the near projection plane in view space.
    //
    //   top:
    //     The Y coordinate of the top side of the near projection plane in view space.
    //
    //   zNear:
    //     Z distance to the near plane from the origin in view space.
    //
    //   zFar:
    //     Z distance to the far plane from the origin in view space.
    //
    //   frustumPlanes:
    //     Frustum planes struct that contains the view space coordinates of that define
    //     a viewing frustum.
    //
    //   fp:
    //
    // Returns:
    //     A projection matrix with a viewing frustum defined by the plane coordinates passed
    //     in.
    public static MY4X4 Frustum(float left, float right, float bottom, float top, float zNear, float zFar)
    {
        throw new NotImplementedException();
    }
    //
    // Summary:
    //     This function returns a projection matrix with viewing frustum that has a near
    //     plane defined by the coordinates that were passed in.
    //
    // Parameters:
    //   left:
    //     The X coordinate of the left side of the near projection plane in view space.
    //
    //   right:
    //     The X coordinate of the right side of the near projection plane in view space.
    //
    //   bottom:
    //     The Y coordinate of the bottom side of the near projection plane in view space.
    //
    //   top:
    //     The Y coordinate of the top side of the near projection plane in view space.
    //
    //   zNear:
    //     Z distance to the near plane from the origin in view space.
    //
    //   zFar:
    //     Z distance to the far plane from the origin in view space.
    //
    //   frustumPlanes:
    //     Frustum planes struct that contains the view space coordinates of that define
    //     a viewing frustum.
    //
    //   fp:
    //
    // Returns:
    //     A projection matrix with a viewing frustum defined by the plane coordinates passed
    //     in.
    public static MY4X4 Frustum(FrustumPlanes fp)
    {
        throw new NotImplementedException();

    }
    public static MY4X4 Inverse(MY4X4 m)
    {

        throw new NotImplementedException();
    }
    public static bool Inverse3DAffine(MY4X4 input, ref MY4X4 result)
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
    //     Create an orthogonal projection matrix.
    //
    // Parameters:
    //   left:
    //     Left-side x-coordinate.
    //
    //   right:
    //     Right-side x-coordinate.
    //
    //   bottom:
    //     Bottom y-coordinate.
    //
    //   top:
    //     Top y-coordinate.
    //
    //   zNear:
    //     Near depth clipping plane value.
    //
    //   zFar:
    //     Far depth clipping plane value.
    //
    // Returns:
    //     The projection matrix.
    public static MY4X4 Ortho(float left, float right, float bottom, float top, float zNear, float zFar)
    {

        throw new NotImplementedException();
    }
    //
    // Summary:
    //     Create a perspective projection matrix.
    //
    // Parameters:
    //   fov:
    //     Vertical field-of-view in degrees.
    //
    //   aspect:
    //     Aspect ratio (width divided by height).
    //
    //   zNear:
    //     Near depth clipping plane value.
    //
    //   zFar:
    //     Far depth clipping plane value.
    //
    // Returns:
    //     The projection matrix.
    public static MY4X4 Perspective(float fov, float aspect, float zNear, float zFar)
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
    public override bool Equals(object other)
    {

        throw new NotImplementedException();
    }
    public bool Equals(MY4X4 other)
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
    public override int GetHashCode()
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
    public override string ToString()
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
    public string ToString(string format)
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
    public string ToString(string format, IFormatProvider formatProvider)
    {

        throw new NotImplementedException();
    }
    //
    // Summary:
    //     Returns a plane that is transformed in space.
    //
    // Parameters:
    //   plane:
    public Plane TransformPlane(Plane plane)
    {

        throw new NotImplementedException();
    }
    //
    // Summary:
    //     Checks if this matrix is a valid transform matrix.
    public bool ValidTRS()
    {

        throw new NotImplementedException();
    }

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
}
