using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    void OnTriggerStay()
    {
        AttachArrow();
    }
    void OnTriggerEnter() //unnessesarry since we have onTriggerStay
    {
        AttachArrow();
    }

    private void AttachArrow()
    {
        var device = SteamVR_Controller.Input((int)ArrowOrganizer.Instance.trackedObj.index);
        if(device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            ArrowOrganizer.Instance.AttachBowToArrow();
        }
    }
}
