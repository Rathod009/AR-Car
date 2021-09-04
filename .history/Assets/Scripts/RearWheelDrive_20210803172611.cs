using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearWheelDrive : MonoBehaviour
{
    public float maxAngle = 60;
    public float maxTorque = 10000;

    public WheelCollider[] wheelArray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     float angle = maxAngle * Input.GetAxis("Horizontal");
     float torque = maxTorque * Input.GetAxis("Vertical");

     wheelArray[0].steerAngle = angle;
     wheelArray[1].steerAngle = angle;
     
     wheelArray[2].motorTorque = torque;
     wheelArray[3].motorTorque = torque;
    }
}
