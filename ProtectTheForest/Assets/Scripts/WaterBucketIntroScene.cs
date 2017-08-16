using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterBucketIntroScene : MonoBehaviour {

    GameObject entireBucket;
    public GameObject balloonPoof;
    float startTime = 0;
    bool hit = false;

    void Start()
    {
        entireBucket = this.gameObject.transform.parent.gameObject;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Arrow"))
        {
            Arrow.DestroyArrow(col.gameObject);
            Vector3 location = this.gameObject.transform.position;
            entireBucket.SetActive(false);
            Instantiate(balloonPoof, location, Quaternion.identity);
            hit = true;
            Debug.Log("loading scene");
            SceneManager.LoadScene(1);
        }
    }
}
