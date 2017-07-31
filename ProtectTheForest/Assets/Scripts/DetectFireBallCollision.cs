﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Detects if this instance of fireball collides with the terrain.
public class DetectFireBallCollision : MonoBehaviour {

    GameObject FireBallManager;
    FireSpawner fs;

    public GameObject WaterBucket;
    WaterBucketOrganizer bucketOrganizer;

    // Use this for initialization
    void Start () {
        FireBallManager = GameObject.Find("FireBallManager");
        fs = FireBallManager.GetComponent<FireSpawner>();

        bucketOrganizer = WaterBucket.GetComponent<WaterBucketOrganizer>();
    }
	
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Burnable"))
        {
            fs.StartFire(this.gameObject.transform.position);
            fs.destroyFireBall(this.gameObject);
            bucketOrganizer.InstantiateWaterBucket(this.gameObject.transform.position);
        }

        else if (col.gameObject.CompareTag("NotBurnable")) // am i still instantiating fire in the water
        {
            fs.destroyFireBall(this.gameObject);
        }
    }
}
