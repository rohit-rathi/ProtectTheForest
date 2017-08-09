using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPicker : MonoBehaviour {

    public AudioSource[] sizzlingFire;
    public AudioSource[] fireballHit;
    public AudioSource[] lifeLost;
    public AudioSource lifeBack;

    int sizzlingIndex = 0;
    int fireballHitIndex = 0;
    int lifeLostIndex = 0;

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

    public void PlayLifeLost()
    {
        lifeLost[lifeLostIndex].Play();
        lifeLostIndex++;
        if (lifeLostIndex > 5)
        {
            lifeLostIndex = 0;
        }
    }

    public void PlayLifeBack()
    {
        lifeBack.Play();
    }

    public void PlayGameOver()
    {

    }
}
