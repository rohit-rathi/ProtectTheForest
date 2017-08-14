using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

    public GameObject balloonPop;
    public GameObject WaterBucket;
    WaterBucketOrganizer bucketOrganizer;
    GameMaster gm;

    // Use this for initialization
    void Start () {
        bucketOrganizer = WaterBucket.GetComponent<WaterBucketOrganizer>();
        gm = GameObject.Find("GameMasterObj").GetComponent<GameMaster>();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Arrow"))
        {
            Arrow.DestroyArrow(col.gameObject);
            DestroyBalloon(this.gameObject.transform.position);
        }
    }

    void DestroyBalloon(Vector3 hitPosition)
    {
        Destroy(this.gameObject);
        Instantiate(balloonPop, hitPosition, Quaternion.identity);
        bucketOrganizer.DecrementBalloonCount();
        gm.IncreaseScore();
        if(this.gameObject.tag == "SpecialBalloon")
        {
            gm.IncreaseLife();
        }
    }
}