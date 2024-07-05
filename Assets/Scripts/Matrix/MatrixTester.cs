using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using customMath;
public class MatrixTester : MonoBehaviour
{
    MY4X4 myMatrix;
    Matrix4x4 matrix;

    [SerializeField] List<Vector4> vector4s = new List<Vector4>();
    [SerializeField] Vector3 translation;
    [SerializeField] Vector3 scale;
    [SerializeField] MyQuaternion rotation;

    [SerializeField] Vector3 point;

    [ContextMenu("Test")]
    void Test()
    {
        myMatrix = MY4X4.TRS(translation, rotation, scale);
        matrix = Matrix4x4.TRS(translation, rotation.toQuaternion, scale);

        Debug.Log($"My matrix vec3 Mul {myMatrix.MultiplyPoint(point)}");
        Debug.Log($"Unity matrix vec3 Mul {matrix.MultiplyPoint(point)}");
    }
}
