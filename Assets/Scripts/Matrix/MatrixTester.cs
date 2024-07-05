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

    [Header("LOOK AT")]
    [SerializeField] Vector3 from;
    [SerializeField] Vector3 to;
    [SerializeField] Vector3 up;


    [ContextMenu("Test")]
    void Test()
    {
        myMatrix = MY4X4.TRS(translation, rotation, scale);
        matrix = Matrix4x4.TRS(translation, rotation.toQuaternion, scale);

        MY4X4 myInverse = MY4X4.Inverse(myMatrix);
        Matrix4x4 unityInverse = Matrix4x4.Inverse(matrix);
        Debug.Log($"My matrix : {myInverse}");
        Debug.Log($"Unity matrix : {unityInverse}");

        Debug.Log($"My matrix mul with original: {myMatrix * myInverse}");
        Debug.Log($"Unity mul with original: {matrix * unityInverse}");
    }
}
