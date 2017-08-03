using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBucketOrganizer : MonoBehaviour
{
    public GameObject waterBucket;
    public GameObject balloonPoof;
    public GameObject explosion;
    Vector3 instantiatedPosition;
    GameObject water;
    GameObject FireBallManager;
    FireSpawner fs;
    GameMaster gm;

    int balloonCount = 1;
    int maxBucketHeight = 60;

    bool instantiatedFireBurst = false;

    float startTimeOfExplosion = 0;

    bool needToDropWater = false;

    // Use this to give a unique ID to each bucket
    static int IDNumber = -1;
    int ID;

    // Use this for initialization
    void Start()
    {
        water = this.gameObject.transform.Find("WaterParticles").gameObject;

        FireBallManager = GameObject.Find("FireBallManager");
        fs = FireBallManager.GetComponent<FireSpawner>();
        gm = GameObject.Find("GameMasterObj").GetComponent<GameMaster>();


        ID = ++IDNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (balloonCount > 0)
        {
            if (this.gameObject.transform.position.y < maxBucketHeight)
            {
                this.gameObject.transform.Translate(0, 2f * Time.deltaTime, 0, Space.World);
            }
            else
            {
                DestroyEntireBucket(this.gameObject.transform.position);
                gm.DecreaseLives();
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

                instantiatedFireBurst = true;
                needToDropWater = true;

            }

            if(needToDropWater)
            {
                if (water.transform.position.y > instantiatedPosition.y)
                {
                    water.transform.Translate(0, -7f * Time.deltaTime, 0, Space.World);
                }
                else
                {
                    fs.destroyFire(ID);
                    needToDropWater = false;
                    Destroy(this.gameObject);
                }
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
        instantiatedPosition = location;
    }

    public void DecrementBalloonCount()
    {
        balloonCount--;
    }
}
