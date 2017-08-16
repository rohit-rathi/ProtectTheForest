using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroStartTraining : MonoBehaviour {

    public GameObject trainingManager;
    StartTraining startTrainingScript;
    public Text fourthText;
    public GameObject fireball;
    public GameObject bucket;
    public Button restartTraining;


    // Use this for initialization
    void Start()
    {
        startTrainingScript = trainingManager.GetComponent<StartTraining>();
    }
    void OnTriggerEnter()
    {
        if(this.gameObject.tag == "restartTrainingButton")
        {
            fourthText.gameObject.SetActive(false);
            fireball.SetActive(false);
            bucket.SetActive(false);
            restartTraining.gameObject.SetActive(false);
        }
        startTrainingScript.BeginTraining();
    }
}
