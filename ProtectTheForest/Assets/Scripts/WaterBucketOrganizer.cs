using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBucketOrganizer : MonoBehaviour
{

    public GameObject waterBucket;
    public GameObject balloonPoof;

    public GameObject[] waterParticles;
    int balloonCount = 2;
    int MAX_BUCKET_HEIGHT = 60;

    bool hasBeenRotated = false;
    float startTime = 0;

    public Animator bucketRotationAnimation;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (balloonCount > 0)
        {
            if (this.gameObject.transform.position.y < MAX_BUCKET_HEIGHT)
            {
                this.gameObject.transform.Translate(0, 2f * Time.deltaTime, 0, Space.World);
            }
            else
            {
                DestroyEntireBucket(this.gameObject.transform.position);
            }
        }
        else
        {
            //destroy the strings
            //rotate the bucket --> use Triggers
            Debug.Log("Setting trigger");
            bucketRotationAnimation.SetTrigger("Change");
            Debug.Log("should rotate now!");
            // then clal DropWaterBucket
            DropWaterBucket();
        }
    }

    void DestroyEntireBucket(Vector3 poofLocation)
    {
        Destroy(this.gameObject);
        Instantiate(balloonPoof, poofLocation, Quaternion.identity);
    }

    public void InstantiateWaterBucket(Vector3 location)
    {
        Instantiate(waterBucket, location, Quaternion.identity);
    }

    public void DecrementBalloonCount()
    {
        balloonCount--;
    }

    void DropWaterBucket()
    {
        if (this.gameObject.transform.position.y > 0)
        {
            this.gameObject.transform.Translate(0, -2f * Time.deltaTime, 0, Space.World);
        }
    }
}
