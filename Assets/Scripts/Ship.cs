 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float MinSpeed = 2f;
    public float MaxSpeed = 10f;
    float CurrentSpeed; 
    void Start()
    {
        
    }

    
    void Update()
    {
        var TargetSpeed = MinSpeed;
        if (Input.GetKey(KeyCode.W))
        {
            TargetSpeed = MaxSpeed;
        }
        CurrentSpeed = Mathf.Lerp(CurrentSpeed, TargetSpeed, Time.deltaTime); 
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.forward * CurrentSpeed;
    }
}
