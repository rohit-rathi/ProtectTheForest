using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketDetection : MonoBehaviour {
    
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("BucketDetection"))
        {
            Debug.Log("hit target");
            Destroy(col.gameObject.transform.parent.gameObject);
            Debug.Log("destroyed fire");
        }
    }
}
