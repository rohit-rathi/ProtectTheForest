using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBucketOrganizer : MonoBehaviour {

    public GameObject waterBucket;
    public GameObject balloonPoof;

    int balloonCount = 2;
    int MAX_BUCKET_HEIGHT = 60;

    // Use this for initialization
    void Start () {
        Debug.Log("imma here");
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.transform.position.y < MAX_BUCKET_HEIGHT)
        {
            Debug.Log("Entered moving bucket up");
            this.gameObject.transform.Translate(0, 2f * Time.deltaTime, 0, Space.World);
        }
        else
        {
            DestroyEntireBucket(this.gameObject.transform.position);
        }
    }

    void DestroyEntireBucket(Vector3 poofLocation)
    {
        Destroy(this.gameObject);
        Instantiate(balloonPoof, poofLocation, Quaternion.identity);
    }

    public void InstantiateWaterBucket(Vector3 location) // move this to DetectFireBallCollision
    {
        Debug.Log("Entered instantiated water bucket method");
        Instantiate(waterBucket, location, Quaternion.identity);
    }

    public void DecrementBalloonCount()
    {
        balloonCount--;
        if(balloonCount == 0)
        {
            // call a method that will cause the bucket to fall and rotate as it falls so that the water
            DropWaterBucket(); 
        }
    }

    void DropWaterBucket()
    {

    }

    public void DestroyBalloon(GameObject balloonToDestroy)
    {

    }
}
