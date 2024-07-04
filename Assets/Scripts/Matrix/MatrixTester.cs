using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixTester : MonoBehaviour
{
    MY4X4 myMatrix;
    Matrix4x4 matrix;

    [SerializeField] List<Vector4> vector4s = new List<Vector4>();


    [ContextMenu("Test")]
    void Test()
    {
        myMatrix = new MY4X4(vector4s[0], vector4s[1], vector4s[2], vector4s[3]);
        matrix = new Matrix4x4(vector4s[0], vector4s[1], vector4s[2], vector4s[3]);

        Debug.Log($"my matrix:\n{myMatrix}");
        Debug.Log($"unity's matrix:\n {matrix}");
    }
}
