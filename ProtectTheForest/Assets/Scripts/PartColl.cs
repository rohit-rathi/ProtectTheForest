using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartColl : MonoBehaviour {
    int detectCount = 0;
        void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("BucketDetection"))
        {
            detectCount++;
            Debug.Log("detecting bucket :" + detectCount);
        }
    }
}
