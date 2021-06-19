using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour
{
    public GameObject CannonBallPrefab;
    


    public Vector3 SpawnPositionLeft;
    public Vector3 ShootDirectionLeft;

    public Vector3 SpawnPositionRight;
    public Vector3 ShootDirectionRight;

    public float ShootPeriod = 1f;
    float LastShootTime = 0;

    
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        if (Time.timeSinceLevelLoad - LastShootTime < ShootPeriod) return;

        LastShootTime = Time.timeSinceLevelLoad;

        var camera = FindObjectOfType<Camera>();
        var direction = camera.GetCameraLookDirection();

        if (direction == CameraLookDirection.FORWARD || direction == CameraLookDirection.BACKWARD)
            return;

        var lookLeft = direction == CameraLookDirection.LEFT;
        var SpawnPosition = lookLeft ? SpawnPositionLeft : SpawnPositionRight;
        var ShootDirection = lookLeft ? ShootDirectionLeft : ShootDirectionRight;

        var ball = Instantiate(CannonBallPrefab);
        
        ball.transform.position = transform.position + transform.rotation * SpawnPosition;
        

        var rigidbody = ball.GetComponent<Rigidbody>();
        rigidbody.velocity = transform.rotation * ShootDirection;
    }
}
