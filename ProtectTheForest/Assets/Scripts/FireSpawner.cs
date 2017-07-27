using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour {

    int minCordinate = -17;
    int maxCordinate = 17;
    int heightOfSpawn = 200;
    int TIME_TO_START_FIREBALLS = 4;

    public GameObject fireBall;
    public GameObject fireOnLand;
    int xInstantiated;
    int zInstantiated;
    int xMinNotValidCoordinate = -14;
    int xMaxNotValidCoordinate = -10;
    int zMinNotValidCoordinate = 0;
    int zMaxNotValidCoordinate = 9;


    ArrayList listOfAllFires = new ArrayList(); // need this to see when counter is at 0 are there any fires still remaining to add more time
    
    // Use this for initialization
    void Start () {
        InvokeRepeating("InstantiateFireBalls", TIME_TO_START_FIREBALLS, 5);
    }

    // Update is called once per frame
    void Update () {

	}

    public void InstantiateFireBalls()
    {
        int xCount = 0;
        do
        {
            xCount++;
            xInstantiated = Random.Range(minCordinate, maxCordinate);
        } while ((xInstantiated >= xMinNotValidCoordinate) && (xInstantiated <= xMaxNotValidCoordinate));

        int zCount = 0;
        do
        {
            zCount++;
            zInstantiated = Random.Range(minCordinate, maxCordinate);
        } while ((zInstantiated >= zMinNotValidCoordinate) && (zInstantiated <= zMaxNotValidCoordinate));
        Debug.Log("xCount: " + xCount + "....!!!!.... zCount " + zCount + ".");

        Instantiate(fireBall, new Vector3(xInstantiated, heightOfSpawn, zInstantiated), Quaternion.identity);
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
