using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondNextButton : MonoBehaviour {

    public Button asteroidsButton;
    public GameObject trainingManager;
    StartTraining startTrainingScript;

    // Use this for initialization
    void Start()
    {
        startTrainingScript = trainingManager.GetComponent<StartTraining>();
    }
    void OnTriggerEnter()
    {
        asteroidsButton.gameObject.SetActive(true);
        startTrainingScript.DisplayThirdInstructions();
    }
}
