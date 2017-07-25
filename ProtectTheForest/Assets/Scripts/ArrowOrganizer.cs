using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOrganizer : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    public SteamVR_TrackedObject otherController;


    public static ArrowOrganizer Instance; //singleton

    public GameObject arrowObject;
    private GameObject currentArrow; // reference to current arrow in our hand\
    public GameObject stringOnBow;
    public GameObject arrowStartPoint;
    public GameObject stringStartPoint;
    public GameObject stringMaxPull;

    private float dist;
    private float maxDist;

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
        maxDist = (stringStartPoint.transform.position - stringMaxPull.transform.position).magnitude;
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
            currentArrow = Instantiate(arrowObject);
            currentArrow.transform.parent = trackedObj.transform;
            currentArrow.transform.localPosition = new Vector3(0f, 0f, .342f);
            currentArrow.transform.localRotation = Quaternion.identity;
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
            var device = SteamVR_Controller.Input((int)trackedObj.index);
            var otherDevice = SteamVR_Controller.Input((int)otherController.index);
            dist = (stringStartPoint.transform.position - trackedObj.transform.position).magnitude;
            if(dist >= maxDist)
            {
                dist = maxDist;
            }
            stringOnBow.transform.localPosition = stringStartPoint.transform.localPosition + new Vector3(7f * dist, 0f, 0f);

            // haptic feedback
            ushort amountOfVibration = (ushort)(dist * 400);
            device.TriggerHapticPulse(amountOfVibration);
            otherDevice.TriggerHapticPulse(amountOfVibration);

            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                FireArrow();
            }
        }
    }

    public void AttachBowToArrow()
    {
        currentArrow.transform.parent = stringOnBow.transform;
        currentArrow.transform.position = arrowStartPoint.transform.position;
        currentArrow.transform.rotation = arrowStartPoint.transform.rotation;

        isArrowAttached = true;
    }

    private void FireArrow()
    {
        currentArrow.transform.parent = null;
        currentArrow.GetComponent<Arrow>().arrowIsFired();
        Rigidbody arrowRB = currentArrow.GetComponent<Rigidbody>();
        arrowRB.velocity = currentArrow.transform.forward * 50f * dist;
        arrowRB.useGravity = true;

        stringOnBow.transform.position = stringStartPoint.transform.position; // reset the string so that the bow is ready to be used again
        currentArrow = null;
        isArrowAttached = false;
    }
}
