using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOrganizer : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;

    public static ArrowOrganizer Instance; //singleton

    public GameObject arrowObject;
    private GameObject currentArrow; // reference to current arrow in our hand\
    public GameObject stringOnBow;
    public GameObject arrowStartPoint;
    public GameObject stringStartPoint;

    private bool isArrowAttached = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        AttachArrow();
        PullString();
	}

    void AttachArrow()
    {
        if(currentArrow == null)
        {
            currentArrow = Instantiate(arrowObject, trackedObj.transform.position, trackedObj.transform.rotation);
            currentArrow.transform.parent = trackedObj.transform;
            currentArrow.transform.localPosition = new Vector3(0f, 0f, .342f);
        }
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void PullString()
    {
        if (isArrowAttached)
        {
            float dist = (stringStartPoint.transform.position - trackedObj.transform.position).magnitude;
            stringOnBow.transform.localPosition = stringStartPoint.transform.localPosition + new Vector3(10f * dist, 0f, 0f);
        }
    }

    public void AttachBowToArrow()
    {
        currentArrow.transform.parent = stringOnBow.transform;
        currentArrow.transform.localPosition = arrowStartPoint.transform.localPosition;
        currentArrow.transform.rotation = arrowStartPoint.transform.rotation;

        isArrowAttached = true;
    }
}
