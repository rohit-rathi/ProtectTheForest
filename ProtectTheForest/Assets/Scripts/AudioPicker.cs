using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPicker : MonoBehaviour {

    public AudioSource[] sizzlingFire;
    public AudioSource[] fireballHit;

    int sizzlingIndex = 0;
    int fireballHitIndex = 0;

    public void PlayFireballHit()
    {
        fireballHit[fireballHitIndex].Play();
        fireballHitIndex++;
        if (fireballHitIndex > 9)
        {
            fireballHitIndex = 0;
        }
    }

    public void PlayFireOut()
    {
        sizzlingFire[sizzlingIndex].Play();
        sizzlingIndex++;
        if(sizzlingIndex > 3)
        {
            sizzlingIndex = 0;
        }
    }

    public void PlayGameOver()
    {

    }
}
