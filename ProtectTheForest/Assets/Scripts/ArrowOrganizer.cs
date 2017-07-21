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

    public AudioSource stringSoundSource;
    public AudioClip[] soundFiles;

    private float dist;
    private float maxDist;

    private bool intermittentVibration = true;

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
            if(dist >= maxDist)
            {
                if(intermittentVibration)
                {
                    Debug.Log("vibrate");
                    device.TriggerHapticPulse(400);
                    intermittentVibration = false;
                }
                else
                {
                    Debug.Log("No vibrate");
                    for(int i = 0; i < 100; i++)
                    {
                        device.TriggerHapticPulse(0);
                    }
                    intermittentVibration = true;
                }
            }

            Debug.Log("1");
            //stringSoundSource.PlayOneShot(soundFiles[1]);
            if(!stringSoundSource.isPlaying)
            {
                stringSoundSource.clip = soundFiles[1];
                stringSoundSource.Play();
            }
            Debug.Log("2");

            
            //device.velocity.Normalize

            /*
            bool trigger = true;
            if(trigger)
            {
                device.TriggerHapticPulse(400);
                trigger = false;
            }
            else
            {
                for (int i = 0; i < 1000; i++)
                {
                    device.TriggerHapticPulse(0);
                }
                trigger = true;
            }*/
            

            ushort amountOfVibration = (ushort)(dist * 550);

            device.TriggerHapticPulse(amountOfVibration);
            otherDevice.TriggerHapticPulse(amountOfVibration);
            // play sound of the string based on the speed that the string is being pulled back - the quicker it is the louder the noise

            // figure out how to do the vibrations for when the string is at the max distance! --> the way they do in the lab is with it vibrating intermitantly 
                    
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
        arrowRB.velocity = currentArrow.transform.forward * 35f * dist;
        arrowRB.useGravity = true;

        stringOnBow.transform.position = stringStartPoint.transform.position; // reset the string so that the bow is ready to be used again
        currentArrow = null;
        isArrowAttached = false;
    }
}
