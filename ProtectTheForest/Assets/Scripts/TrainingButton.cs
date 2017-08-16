using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainingButton : MonoBehaviour {

    void OnTriggerEnter()
    {
        SceneManager.LoadScene(1);
    }
}
