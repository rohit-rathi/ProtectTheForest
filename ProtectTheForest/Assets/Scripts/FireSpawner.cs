using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage the fire on the land and the fireball.
public class FireSpawner : MonoBehaviour {

    // square area of where fireballs can be instantiated.
    int minCordinate = -17;
    int maxCordinate = 17;

    int heightOfSpawn = 200;
    int timeToStartFireballs = 5;
    static int timeIntervalOfFireballInstantiation = 6;

    public GameObject fireBall;
    public GameObject fireOnLand;
    public GameObject fireExtinguish;

    // actual x and z cordinates of where fireballs are instantiated
    int xInstantiated;
    int zInstantiated;

    // avoid fireballs being instantitaed directly over player area to ensure no fireballs lands on the player
    int xMinNotValidCoordinate = -14;
    int xMaxNotValidCoordinate = -10;
    int zMinNotValidCoordinate = 0;
    int zMaxNotValidCoordinate = 9;

    // list of all fires instantiated with fireList[0] being the first fire instantiated in the game
    ArrayList fireList = new ArrayList();
    
    // Use this for initialization
    void Start () {
        //InvokeRepeating("InstantiateFireBalls", timeToStartFireballs, timeIntervalOfFireballInstantiation);
        StartCoroutine(InstantiateFireBalls());
    }

    IEnumerator InstantiateFireBalls()
    {
        while (true)
        {
            // get a random VALID x and z coordinates for where fireballs are instantiated
            do
            {
                xInstantiated = Random.Range(minCordinate, maxCordinate);
            } while ((xInstantiated >= xMinNotValidCoordinate) && (xInstantiated <= xMaxNotValidCoordinate));

            do
            {
                zInstantiated = Random.Range(minCordinate, maxCordinate);
            } while ((zInstantiated >= zMinNotValidCoordinate) && (zInstantiated <= zMaxNotValidCoordinate));

            Instantiate(fireBall, new Vector3(xInstantiated, heightOfSpawn, zInstantiated), Quaternion.identity);

            yield return new WaitForSeconds(timeIntervalOfFireballInstantiation);
        }
    }

    public int GetStartFireBall()
    {
        return timeToStartFireballs;
    }

    public void StartFire(Vector3 startPosition)
    {
        fireList.Add(Instantiate(fireOnLand, startPosition, Quaternion.identity));
    }

    public void destroyFire(int fireIndex)
    {
        GameObject fire = (GameObject)fireList[fireIndex];
        Vector3 position = fire.transform.position;
        Destroy(fire);
        Instantiate(fireExtinguish, position, Quaternion.identity);
        //have the sizzling sound play in the background here!!! //////////////////////////***********************************************/////////////////////////////////
    }

    public void destroyFireBall(GameObject ballToDestroy)
    {
        Destroy(ballToDestroy);
    }

    public static void DecreaseFireBallTimeInterval()
    {
        if(timeIntervalOfFireballInstantiation > 1)
        {
            timeIntervalOfFireballInstantiation--;
        }
        //Debug.Log("Decrease time. Time is now " + timeIntervalOfFireballInstantiation);
    }
}
