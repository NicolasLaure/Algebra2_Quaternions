using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using customMath;

public class Tester : MonoBehaviour
{
    [SerializeField] MyQuaternion myQuatA = MyQuaternion.identity;
    [SerializeField] MyQuaternion myQuatB = MyQuaternion.identity;
    [SerializeField] Quaternion quaternionA = Quaternion.identity;
    [SerializeField] Quaternion quaternionB = Quaternion.identity;

    [SerializeField] GameObject myQuatObject;
    [SerializeField] GameObject quaternionObject;

    [SerializeField] private Vector3 eulerAngles;
    [SerializeField] private Vector3 point;
    [SerializeField] private Vector3 up;

    MyQuaternion res;
    Quaternion result;

    private void Awake()
    {
        quaternionA = myQuatA.toQuaternion;
        quaternionB = myQuatB.toQuaternion;

        myQuatObject.transform.rotation = myQuatA.toQuaternion;
        quaternionObject.transform.rotation = quaternionA;

        res = myQuatA;
        result = quaternionA;
    }
    private void Update()
    {
        TestQuaternion();
    }

    [ContextMenu("Test")]
    public void TestQuaternion()
    {
        //Debug.Log($"My quat eulers are: {myQuat.eulerAngles}");
        //Debug.Log($"Unity Quaternion eulers are: {quaternion.eulerAngles}");
        res = MyQuaternion.RotateTowards(res, myQuatB, -0.5f);
        Debug.Log($"My Quat RotateTowards: {res} ");
        result = Quaternion.RotateTowards(result, quaternionB, -0.5f);
        Debug.Log($"Quaternion RotateTowards: {result} ");

        myQuatObject.transform.rotation = res.toQuaternion;
        quaternionObject.transform.rotation = result;

        //Debug.Log($"MyQuaternion based on euler angles returns: {myQuatA}");
        //Debug.Log($"Quaternion based on euler angles returns: {quaternionA}");
    }
}
