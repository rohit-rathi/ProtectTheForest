using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

    void OnTriggerEnter()
    {
        Debug.Log("restart");
        //DestroyAllGameObjects();
        SceneManager.LoadScene(0);
    }

    void DestroyAllGameObjects()
    {
        GameObject[] gameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }
}
