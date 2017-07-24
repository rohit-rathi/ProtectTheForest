using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFireBallCollision : MonoBehaviour {

    GameObject FireBallManager;
    FireSpawner fs;
    
    // Use this for initialization
    void Start () {
        FireBallManager = GameObject.Find("FireBallManager");
        fs = FireBallManager.GetComponent<FireSpawner>();
        if (fs == null)
        {
            Debug.Log("no object found");
        }
        else
        {
            Debug.Log("Object found");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Burnable"))
        {
            Debug.Log("Burnable");
            fs.StartFire(this.gameObject.transform.position);
           // fs.destroyFireBall(this);
        }

        else if (col.gameObject.CompareTag("NotBurnable"))
        {
            Debug.Log("Not Burnable");
        }
    }
}
