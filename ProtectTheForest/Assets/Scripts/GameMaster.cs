using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    private static int lives = 5;
    public GameObject endFire;
    bool gameOver = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if(!gameOver && lives <= 0)
        {
            endFire.SetActive(true);
            gameOver = true;
        }
		
	}

    public static void DecreaseLives()
    {
        lives--;
    }
}
