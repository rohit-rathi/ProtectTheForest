using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    private static int lives = 5;
    public GameObject endFire;
    bool gameOver = false;
    static int score = 0;
    int nextAddBonusTime = 30;

	// Use this for initialization
	void Start () {
        StartCoroutine(DecreaseBallTimeInterval());
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameOver && Time.time >= nextAddBonusTime)
        {
            score += 30;
            nextAddBonusTime += 30;
        }

        if (!gameOver && lives <= 0)
        {
            endFire.SetActive(true);
            gameOver = true;
        }
    }

    IEnumerator DecreaseBallTimeInterval()
    {
        while(true)
        {
            FireSpawner.DecreaseFireBallTimeInterval();
            yield return new WaitForSeconds(20f);
        }
    }

    public static void DecreaseLives()
    {
        lives--;
    }

    public static void IncreaseScore()
    {
        score += 10;
    }
}
