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

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Arrow"))
        {
            DestroyBalloon(this.gameObject.transform.position);
        }
    }
    void DestroyBalloon(Vector3 hitPosition)
    {
        Destroy(this.gameObject);
        Instantiate(balloonPop, hitPosition, Quaternion.identity);
        bucketOrganizer.DecrementBalloonCount();
    }
}
