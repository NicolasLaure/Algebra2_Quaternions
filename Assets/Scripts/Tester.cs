using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using customMath;

public class Tester : MonoBehaviour
{
    [SerializeField] MyQuaternion myQuat = MyQuaternion.identity;
    [SerializeField] Quaternion quaternion;

    [SerializeField] GameObject myQuatObject;
    [SerializeField] GameObject quaternionObject;

    private void Update()
    {
        myQuatObject.transform.rotation = myQuat.toQuaternion;
        quaternionObject.transform.rotation = quaternion;
    }

    [ContextMenu("Test")]
    public void TestQuaternion()
    {
        //Debug.Log($"My quat eulers are: {myQuat.eulerAngles}");
        //Debug.Log($"Unity Quaternion eulers are: {quaternion.eulerAngles}");
        Debug.Log($"My quat normalized is: { MyQuaternion.Normalize(myQuat)}");
        Debug.Log($"Unity Quaternion normalized is: {Quaternion.Normalize(quaternion)}");
    }
}
