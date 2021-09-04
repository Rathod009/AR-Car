using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RearWheelDrive : MonoBehaviour
{
    public float maxAngle = 60;
    public float maxTorque = 10;
    public bool isBreakDown = false;

    public Transform breakIcon;

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
     if(!isBreakDown)
    {
        wheelColliderArray[2].motorTorque = torque;
        wheelColliderArray[3].motorTorque = torque;
    }
     else
     {
         wheelColliderArray[2].brakeTorque = 300;
        wheelColliderArray[3].brakeTorque = 300;
     }
     
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
        breakIcon.transform.localScale.y = 0.7f;
     }

     public void breakUp()
     {
         isBreakDown = false;
         wheelColliderArray[2].brakeTorque = 0;
        wheelColliderArray[3].brakeTorque = 0;
        breakIcon.localScale.y = 1f;

        
     }
}
