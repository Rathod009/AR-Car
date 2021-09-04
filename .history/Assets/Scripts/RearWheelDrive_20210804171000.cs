using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RearWheelDrive : MonoBehaviour
{
    public float maxAngle = 60;
    public float maxTorque = 10;
    public bool isBreakDown = false;

    public WheelCollider[] wheelColliderArray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     float angle = maxAngle * SimpleInput.GetAxis("Horizontal");
     
     float torque = torque = maxTorque * SimpleInput.GetAxis("Vertical");
     

    wheelColliderArray[0].steerAngle = angle;
    wheelColliderArray[1].steerAngle = angle;
     
     wheelColliderArray[2].motorTorque = isBreakDown ? 0 : torque;
     wheelColliderArray[3].motorTorque = isBreakDown ? 0 : torque;
     Debug.Log(isBreakDown);

     foreach (WheelCollider wheelCollider in wheelColliderArray)
     {
        //get the position & rotation of each wheel collider from the array
        Vector3 p;
        Quaternion ro; 

        wheelCollider.GetWorldPose(out p, out ro);

        //get the reference of each wheel model

        Transform wheelModel = wheelCollider.transform.GetChild(0);

        //assign the posititon of each wheel collider to wheel model

        wheelModel.position = p;

        //assign the rotation of each wheel collider to wheel model

        wheelModel.rotation = ro;
     }

    }

     public void breakDown()
     {
        isBreakDown = true;
     }

     public void breakUp()
     {
         isBreakDown = false;
     }
}
