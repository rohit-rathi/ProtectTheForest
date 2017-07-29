using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            //GameObject fireOnLand = fs.StartFire(this.gameObject.transform.position);
            fs.StartFire(this.gameObject.transform.position);
            fs.destroyFireBall(this.gameObject);
            bucketOrganizer.InstantiateWaterBucket(this.gameObject.transform.position);
        }

        else if (col.gameObject.CompareTag("NotBurnable"))
        {
            fs.destroyFireBall(this.gameObject);
        }
    }
}
