using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBucketOrganizer : MonoBehaviour
{

    public GameObject waterBucket;
    public GameObject balloonPoof;
    public GameObject explosion;

    public GameObject[] waterParticles;
    int balloonCount = 1;
    int MAX_BUCKET_HEIGHT = 60; // need to change this

    bool hasBeenRotated = false;
    float startTime = 0;

    GameObject explosionCopy;
    bool instantiatedFireBurst = false;

    float startTimeOfExplosion = 0;
    bool needToDestroyExplosion = false;

    // Use this for initialization
    void Start()
    {

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
            if(!instantiatedFireBurst)
            {
                //destroy all objects except water particles
                Destroy(this.gameObject.transform.Find("Bucket").gameObject);
                Destroy(this.gameObject.transform.Find("String").gameObject);
                Destroy(this.gameObject.transform.Find("String (1)").gameObject);
                Destroy(this.gameObject.transform.Find("Point light").gameObject);
                Destroy(this.gameObject.transform.Find("Point light (1)").gameObject);
                Destroy(this.gameObject.transform.Find("Point light (2)").gameObject);
                Destroy(this.gameObject.transform.Find("Point light (3)").gameObject);

                //enable an explosion
                explosionCopy = Instantiate(explosion, this.gameObject.transform.position, Quaternion.identity);
                instantiatedFireBurst = true;
                needToDestroyExplosion = true;
            }

            startTime += Time.deltaTime;

            if (startTime >= 2 && needToDestroyExplosion)
            {
                Destroy(explosionCopy);
                needToDestroyExplosion = false;
            }
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
}
