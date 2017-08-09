using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    private static int lives = 6;
    public GameObject endFire;
    bool gameOver = false;
    static int score = 0;
    int nextAddBonusTime = 30;
    public Text scoreText;
    public Text livesText;
    public Text gameOverText;
    int bonusPoints = 0;
    static int fireBallTimeIntervalSeconds = 15;
    float startTime = 0;
    AudioPicker picker;
    int nextGoldenBalloonTime = 60;

    // Use this for initialization
    void Start () {
        StartCoroutine(DecreaseBallTimeInterval());
        SetScoreText();
        SetLivesText();
        gameOverText.text = "";

        picker = GameObject.Find("ImpactSound").GetComponent<AudioPicker>();
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

        if(!gameOver && Time.time >= nextGoldenBalloonTime)
        {
            DetectFireBallCollision.changeTypeOfBucket();
            nextGoldenBalloonTime += 40;
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
            yield return new WaitForSeconds(fireBallTimeIntervalSeconds);
        }
    }

    public void DecreaseLives()
    {
        if (lives > 0)
        {
            lives--;
            picker.PlayLifeLost();
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

    public static void ChangeFireBallTimeIntervalSeconds(int value)
    {
        fireBallTimeIntervalSeconds = value;
    }

    public void IncreaseLife()
    {
        if (lives < 6)
        {
            lives++;
        }
        SetLivesText();
        picker.PlayLifeBack();
    }
}
