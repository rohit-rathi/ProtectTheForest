using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBucketIntroScene : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, 4 + Mathf.Sin(Time.time * 4.0f), transform.position.z);
	}
}
