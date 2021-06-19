using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour
{
    public GameObject WaterPS;
    public GameObject TerrainPS;
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        var layerID = collision.collider.gameObject.layer;
        var layerName = LayerMask.LayerToName(layerID);
        
        GameObject particlesObject = null;
        if (layerName == "Water")
            particlesObject = WaterPS;
        if (layerName == "Terrain")
            particlesObject = TerrainPS;


        var position = collision.contacts[0].point;

        Instantiate(particlesObject, position, Quaternion.identity);
        Destroy(gameObject);
    }
}
