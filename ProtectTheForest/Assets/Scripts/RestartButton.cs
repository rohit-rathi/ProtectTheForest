﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

    void OnTriggerEnter()
    {
        SceneManager.LoadScene(0);        
    }
}
