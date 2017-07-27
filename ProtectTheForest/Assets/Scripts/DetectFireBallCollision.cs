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
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Burnable"))
        {
            fs.StartFire(this.gameObject.transform.position);
            fs.destroyFireBall(this.gameObject);
            bucketOrganizer.InstantiateWaterBucket(this.gameObject.transform.position);
        }

        else if (col.gameObject.CompareTag("NotBurnable"))
        {
            Debug.Log("in water");
            fs.destroyFireBall(this.gameObject);
            Debug.Log("destroyed");
        }
    }
}
