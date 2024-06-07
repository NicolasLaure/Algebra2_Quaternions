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

    private void Awake()
    {
        quaternionA = myQuatA.toQuaternion;
        quaternionB = myQuatB.toQuaternion;
    }
    private void Update()
    {
        myQuatObject.transform.rotation = myQuatA.toQuaternion;
        quaternionObject.transform.rotation = quaternionA;
    }

    [ContextMenu("Test")]
    public void TestQuaternion()
    {
        //Debug.Log($"My quat eulers are: {myQuat.eulerAngles}");
        //Debug.Log($"Unity Quaternion eulers are: {quaternion.eulerAngles}");

        Debug.Log($"The multiplication between myquat A and B is: {myQuatA * myQuatB}");
        Debug.Log($"The multiplication between unity Quaternions A and B is: {quaternionA * quaternionB}");
    }
}
