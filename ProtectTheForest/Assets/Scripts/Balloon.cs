using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

    public GameObject balloonPop;
    public GameObject WaterBucket;
    WaterBucketOrganizer bucketOrganizer;

    // Use this for initialization
    void Start () {
        bucketOrganizer = WaterBucket.GetComponent<WaterBucketOrganizer>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Arrow"))
        {
            Debug.Log("Arrow hit me");
            DestroyBalloon(col.gameObject.transform.position);
        }
    }

    void DestroyBalloon(Vector3 hitPosition)
    {
        Destroy(this.gameObject);
        Instantiate(balloonPop, hitPosition, Quaternion.identity);
    }
}
