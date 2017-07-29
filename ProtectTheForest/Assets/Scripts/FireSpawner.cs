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

    ArrayList fireList = new ArrayList();
    
    // Use this for initialization
    void Start () {
        InvokeRepeating("InstantiateFireBalls", TIME_TO_START_FIREBALLS, 5);
    }

    // Update is called once per frame
    void Update () {

	}

    public void InstantiateFireBalls()
    {
        do
        {
            xInstantiated = Random.Range(minCordinate, maxCordinate);
        } while ((xInstantiated >= xMinNotValidCoordinate) && (xInstantiated <= xMaxNotValidCoordinate));

        do
        {
            zInstantiated = Random.Range(minCordinate, maxCordinate);
        } while ((zInstantiated >= zMinNotValidCoordinate) && (zInstantiated <= zMaxNotValidCoordinate));

        Instantiate(fireBall, new Vector3(xInstantiated, heightOfSpawn, zInstantiated), Quaternion.identity);
    }

    // use this to display countdown for asteroids so user is aware --> have a personal assistant speak to you -> like jarvis
    public int GetStartFireBall()
    {
        return TIME_TO_START_FIREBALLS;
    }

    public void StartFire(Vector3 startPosition)
    {
        fireList.Add(Instantiate(fireOnLand, startPosition, Quaternion.identity));
    }

    public void destroyFire(int fireIndex)
    {
        GameObject fire = (GameObject)fireList[fireIndex];
        //fire.SetActive(false);
        Destroy(fire);
    }

    public void destroyFireBall(GameObject ballToDestroy)
    {
        Destroy(ballToDestroy);
    }
}
