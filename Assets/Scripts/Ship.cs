 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float MinSpeed = 2f;
    public float MaxSpeed = 10f;
    float CurrentSpeed;
    public float MaxAngle = 30;
    float CurrentAngle = 0;
    void Start()
    {
        
    }

    
    void Update()
    {
        //target veocity
        var TargetSpeed = Input.GetKey(KeyCode.W) ? MaxSpeed : MinSpeed;
        CurrentSpeed = Mathf.Lerp(CurrentSpeed, TargetSpeed, Time.deltaTime);

        //target angle
        var TargetAngle = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            TargetAngle = - MaxAngle;
        }
        if (Input.GetKey(KeyCode.D))
        {
            TargetAngle = MaxAngle;
        }
        CurrentAngle = Mathf.Lerp(CurrentAngle, TargetAngle, Time.deltaTime / 2f);
        
        //movment
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.rotation *= Quaternion.Euler(Vector3.up * CurrentAngle * Time.deltaTime);
        rigidbody.velocity =  rigidbody.rotation * Vector3.back * CurrentSpeed;
        
    }
}
