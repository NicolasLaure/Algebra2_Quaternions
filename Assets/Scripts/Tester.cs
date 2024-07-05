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

    [Header("LOOK ROTATION")]
    [SerializeField] Vector3 forward;
    [SerializeField] Vector3 upwards;

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
        //res = MyQuaternion.RotateTowards(res, myQuatB, -0.5f);
        //Debug.Log($"My Quat RotateTowards: {res} ");
        //result = Quaternion.RotateTowards(result, quaternionB, -0.5f);
        //Debug.Log($"Quaternion RotateTowards: {result} ");
        //Debug.Log(myQuatA * point);
        //Debug.Log(quaternionA * point);
        //myQuatObject.transform.rotation = res.toQuaternion;
        //quaternionObject.transform.rotation = result;


        Debug.Log($"My Look Rotation: {MyQuaternion.LookRotation(forward, upwards)}");
        Debug.Log($"Unity Look Rotation: {Quaternion.LookRotation(forward, upwards)}");

        //Debug.Log($"MyQuaternion based on euler angles returns: {myQuatA}");
        //Debug.Log($"Quaternion based on euler angles returns: {quaternionA}");
    }
}
