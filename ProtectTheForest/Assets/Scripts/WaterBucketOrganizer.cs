using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBucketOrganizer : MonoBehaviour {

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
    void Start () {
        anim = GetComponentInChildren<Animator>();
        bucketRotationAnimation.StartPlayback();
	}
	
	// Update is called once per frame
	void Update () {

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
            ActivateRotation();
            if(hasBeenRotated)
            {
                Debug.Log("stop");
                bucketRotationAnimation.StopPlayback();
            }
            //if (!hasBeenRotated)
            //{
            //    Debug.Log("all balloons shot");
            //    //anim.Play("BucketRotation");
            //    anim.enabled = true;
            //    Debug.Log("played animation and now setting it bool to true");
            //    hasBeenRotated = true;
            //    anim.enabled = false;
            //}
            
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
        //Debug.Log("Entering drop bucket mode");
        ////need to call the animation
        //Quaternion startRotation = Quaternion.Euler(0f, 0f, 0f);
        //Quaternion endRotation = startRotation * Quaternion.Euler(0f, 0f, 180f);
        //this.gameObject.transform.rotation = Quaternion.Slerp(startRotation, endRotation, startTime/2f);
        //this.gameObject.transform.Translate(0f, Time.deltaTime * 2f, 0);
        //startTime += Time.deltaTime;
        //if(this.gameObject.transform.rotation.z == 180)
        //{
        //    hasBeenRotated = true;
        //}
    }

    public void ActivateRotation()
    {
        Debug.Log("Setting to true");
        hasBeenRotated = true;
        bucketRotationAnimation.SetBool("Rotate", true);
    }
}
