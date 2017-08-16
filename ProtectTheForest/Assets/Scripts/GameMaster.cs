using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    private static int lives;
    bool gameOver = false;
    static int score;
    int nextAddBonusTime = 30;
    public Text scoreText;
    public Text livesText;
    public Text gameOverText;
    int bonusPoints = 0;
    static int fireBallTimeIntervalSeconds = 15;
    float startTime = 0;
    AudioPicker picker;
    int nextGoldenBalloonTime = 60;
    public GameObject bowController;
    public Button restart;
    public Button training;
    GameObject FireBallManager;
    FireSpawner fs;
    static int bucketID;
    float time;


    void Awake()
    {
        SetScoreText();
        SetLivesText();
        lives = 6;
        score = 0;
        fireBallTimeIntervalSeconds = 15;
        bucketID = -1;
        time = 0;
    }
    // Use this for initialization
    void Start()
    {
        StartCoroutine(DecreaseBallTimeInterval());
        SetScoreText();
        SetLivesText();
        gameOverText.text = "";

        picker = GameObject.Find("ImpactSound").GetComponent<AudioPicker>();
        FireBallManager = GameObject.Find("FireBallManager");
        fs = FireBallManager.GetComponent<FireSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (!gameOver && time >= nextAddBonusTime)
        {
            score += 30;
            nextAddBonusTime += 30;
            SetScoreText();
            bonusPoints++;
        }

        if (!gameOver && time >= nextGoldenBalloonTime)
        {
            DetectFireBallCollision.changeTypeOfBucket();
            nextGoldenBalloonTime += 40;
        }

        if (!gameOver && lives <= 0)
        {
            gameOver = true;
            gameOverText.text = "GAME OVER";
            bowController.SetActive(false);
            restart.gameObject.SetActive(true);
            training.gameObject.SetActive(true);
            fs.changeInstantiateFireballStatus();
            picker.PlayGameOver();

        }
    }

    IEnumerator DecreaseBallTimeInterval()
    {
        while (true)
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
        lives++;
        SetLivesText();
        picker.PlayLifeBack();
    }

    public static void IncrementIDNumber()
    {
        bucketID++;
    }

    public static int returnIDNumber()
    {
        return bucketID;
    }
}
