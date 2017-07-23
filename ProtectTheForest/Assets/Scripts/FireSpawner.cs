using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour {

    float minCordinate = -17.5f;
    float maxCordinate = 17.5f;
    float heightOfSpawn = 600.0f;

    public GameObject fireBall;
    public GameObject fireOnLand;

       
	// Use this for initialization
	void Start () {
        InvokeRepeating("InstantiateFireBalls", 10, 5);
    }

    // Update is called once per frame
    void Update () {

	}

    public void InstantiateFireBalls()
    {
        Instantiate(fireBall, new Vector3(Random.Range(minCordinate, maxCordinate), heightOfSpawn, Random.Range(minCordinate, maxCordinate)), Quaternion.identity);

    }
}
