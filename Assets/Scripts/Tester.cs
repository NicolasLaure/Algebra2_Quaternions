using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using customMath;

public class Tester : MonoBehaviour
{
    MyQuaternion myQuat;
    Quaternion quaternion;

    [ContextMenu("Test")]
    public void TestQuaternion()
    {
        Debug.Log(MyQuaternion.identity);
        Debug.Log(Quaternion.identity);
    }
}
