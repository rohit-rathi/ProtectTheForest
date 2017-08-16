using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroStartGame : MonoBehaviour {

    void OnTriggerEnter()
    {
        SceneManager.LoadScene(1);
    }
}
