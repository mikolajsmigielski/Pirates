using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform ObjectToTrack;
    public Vector3 Delta = new Vector3(0, 20, -40);
    void Start()
    {
        
    } 
    void Update()
    {
        var NewCameraposition = ObjectToTrack.position + Delta;
        transform.position = NewCameraposition;
    }
}
