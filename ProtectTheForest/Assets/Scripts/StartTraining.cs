using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTraining : MonoBehaviour
{
    public Button startGameButton;
    public Button startTrainingButton;

    public GameObject poofPrefab;

    public Text firstText;
    public Button firstNextButton;

    public Text secondText;
    public Button secondNextButton;

    public Button FireballNextButton;

    public GameObject fireball;
    public GameObject waterBucket;
    public Text fourthText;
    public Button restartTraining;

    public void BeginTraining()
    {
        Vector3 startButtonLocation = startGameButton.transform.position;
        Vector3 trainingButtonLocation = startTrainingButton.transform.position;
        GameObject startButtonPoof = Instantiate(poofPrefab, startButtonLocation, Quaternion.identity);
        GameObject trainingButtonPoof = Instantiate(poofPrefab, trainingButtonLocation, Quaternion.identity);
        startGameButton.gameObject.SetActive(false);
        startTrainingButton.gameObject.SetActive(false);
        DisplayFirstInstructions();
    }

    void DisplayFirstInstructions()
    {
        firstText.gameObject.SetActive(true);
        firstNextButton.gameObject.SetActive(true);
    }

    public void DisplaySecondInstructions()
    {
        Vector3 firstTextLocation = firstText.transform.position;
        GameObject firstTextPoof = Instantiate(poofPrefab, firstTextLocation, Quaternion.identity);
        firstText.gameObject.SetActive(false);
        firstNextButton.gameObject.SetActive(false);
        secondText.gameObject.SetActive(true);
        secondNextButton.gameObject.SetActive(true);
    }

    public void DisplayThirdInstructions()
    {
        secondText.gameObject.SetActive(false);
        secondNextButton.gameObject.SetActive(false);
    }

    public void DisplayFourthInstructions()
    {
        FireballNextButton.gameObject.SetActive(false);
        fourthText.gameObject.SetActive(true);
        fireball.SetActive(true);
        waterBucket.SetActive(true);
        restartTraining.gameObject.SetActive(true);
    }
}

