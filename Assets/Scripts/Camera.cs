using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform ObjectToTrack;
    public Vector3 Delta = new Vector3(0, 20, -40);
    float cameraAngle = 0f;
    void Start()
    {
        
    } 
    void Update()
    {
        cameraAngle += Input.GetAxis("Mouse X");
        var quaternion = Quaternion.Euler(0, cameraAngle, 0);

        var NewCameraposition = ObjectToTrack.position + ObjectToTrack.rotation * quaternion * Delta;
        transform.position = NewCameraposition;
        transform.LookAt(ObjectToTrack);
        transform.rotation *= Quaternion.Euler(-10f, 0, 0);
    }
}
