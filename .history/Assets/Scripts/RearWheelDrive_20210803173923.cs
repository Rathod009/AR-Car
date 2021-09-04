using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearWheelDrive : MonoBehaviour
{
    public float maxAngle = 60;
    public float maxTorque = 30000;

    public WheelCollider[] wheelColliderArray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     float angle = maxAngle * Input.GetAxis("Horizontal");
     float torque = maxTorque * Input.GetAxis("Vertical");

    wheelColliderArray[0].steerAngle = angle;
    wheelColliderArray[1].steerAngle = angle;
     
     wheelColliderArray[2].motorTorque = torque;
     wheelColliderArray[3].motorTorque = torque;
    }
}
