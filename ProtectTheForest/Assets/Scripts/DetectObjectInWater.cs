using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjectInWater : MonoBehaviour {

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Arrow"))
        {
            Arrow.DestroyArrow(col.gameObject);
        }
    }
}
