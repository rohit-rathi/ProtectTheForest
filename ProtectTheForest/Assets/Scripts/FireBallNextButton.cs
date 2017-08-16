using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallNextButton : MonoBehaviour {

    public GameObject trainingManager;
    StartTraining startTrainingScript;

    // Use this for initialization
    void Start()
    {
        startTrainingScript = trainingManager.GetComponent<StartTraining>();
    }
    void OnTriggerEnter()
    {
        startTrainingScript.DisplayFourthInstructions();
    }
}
