using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
     
    bool isArrowAttached = false;
    bool isFired = false;
    bool haloOn = false;
    float timeSinceArrowFired = 0;

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
            if(!haloOn)
            {
                TurnOnHalo();
            }
            transform.LookAt(transform.position + transform.GetComponent<Rigidbody>().velocity);
            timeSinceArrowFired += Time.deltaTime;
            if(timeSinceArrowFired >= 10)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void AttachArrow()
    {
        var device = SteamVR_Controller.Input((int)ArrowOrganizer.Instance.trackedObj.index);
        if (!isArrowAttached && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            ArrowOrganizer.Instance.AttachBowToArrow();
            isArrowAttached = true;
        }
    }

    public void arrowIsFired()
    {
        isFired = true;
    }

    public static void DestroyArrow(GameObject arrowToDestroy)
    {
        Destroy(arrowToDestroy);
    }

    void TurnOnHalo()
    {
        Light pointLight = this.gameObject.GetComponentInChildren<Light>();
        Component halo = pointLight.GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
        haloOn = true;
    }


}
