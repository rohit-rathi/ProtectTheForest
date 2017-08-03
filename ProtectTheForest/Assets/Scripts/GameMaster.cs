using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    private static int lives = 5;
    public GameObject endFire;
    bool gameOver = false;
    static int score = 0;
    int nextAddBonusTime = 30;
    public Text scoreText;
    public Text livesText;
    public Text gameOverText;
    int bonusPoints = 0;

	// Use this for initialization
	void Start () {
        StartCoroutine(DecreaseBallTimeInterval());
        SetScoreText();
        SetLivesText();
        gameOverText.text = "";

    }
	
	// Update is called once per frame
	void Update () {
        if (!gameOver && Time.time >= nextAddBonusTime)
        {
            score += 30;
            nextAddBonusTime += 30;
            SetScoreText();
            bonusPoints++;
        }
        
        if (!gameOver && lives <= 0)
        {
            endFire.SetActive(true);
            gameOver = true;
            gameOverText.text = "GAME OVER!\nFinal Score: " + score.ToString();
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

    public void DecreaseLives()
    {
        if (lives > 0)
        {
            lives--;
        }
        SetLivesText();
    }

    public void IncreaseScore()
    {
        score += 10;
        SetScoreText();
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }
}
