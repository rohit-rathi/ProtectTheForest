using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    bool isArrowAttached = false;
    bool isFired = false;

    void OnTriggerStay()
    {
        AttachArrow();
    }
    void OnTriggerEnter() //unnessesarry since we have onTriggerStay
    {
        AttachArrow();
    }

    void Update()
    {
        if (isFired)
        {
            transform.LookAt(transform.position + transform.GetComponent<Rigidbody>().velocity);
        }
    }
    
    private void AttachArrow()
    {
        var device = SteamVR_Controller.Input((int)ArrowOrganizer.Instance.trackedObj.index);
        if(!isArrowAttached && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            ArrowOrganizer.Instance.AttachBowToArrow();
            isArrowAttached = true;
        }
    }

    public void arrowIsFired()
    {
        isFired = true;
    }
}
