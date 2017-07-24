using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour {

    float minCordinate = -17.5f;
    float maxCordinate = 17.5f;
    float heightOfSpawn = 100.0f; // change this back to 300
    int TIME_TO_START_FIREBALLS = 4;

    public GameObject fireBall;
    public GameObject fireOnLand;

   // ArrayList listOfAllFireBalls = new ArrayList();
    ArrayList listOfAllFires = new ArrayList();
    
    // Use this for initialization
    void Start () {
        InvokeRepeating("InstantiateFireBalls", TIME_TO_START_FIREBALLS, 5);
    }

    // Update is called once per frame
    void Update () {

	}

    public void InstantiateFireBalls()
    {
        //listOfAllFireBalls.Add(Instantiate(fireBall, new Vector3(Random.Range(minCordinate, maxCordinate), heightOfSpawn, Random.Range(minCordinate, maxCordinate)), Quaternion.identity));
        Instantiate(fireBall, new Vector3(Random.Range(minCordinate, maxCordinate), heightOfSpawn, Random.Range(minCordinate, maxCordinate)), Quaternion.identity);
    }

    // use this to display countdown for asteroids so user is aware --> have a personal assistant speak to you -> like jarvis
    public int GetStartFireBall()
    {
        return TIME_TO_START_FIREBALLS;
    }

    public void StartFire(Vector3 startPosition)
    {
        listOfAllFires.Add(Instantiate(fireOnLand, startPosition, Quaternion.identity));
    }

    public void destroyFire()
    {

    }

    public void destroyFireBall(GameObject ballToDestroy)
    {
        Destroy(ballToDestroy);
    }
}
