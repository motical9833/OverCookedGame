using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    AudioClip[] extinguisherClip =  new AudioClip[3];
    AudioSource audioSource;

    ParticleSystem powderParticle;
    const string extinguisherStartSound = "ExtinguisherStartSound";
    const string extinguisherStartEnd = "ExtinguisherEndSound";
    const string extinguisherStartLoop = "ExtinguisherLoopSound";

    public void SprayPowder()
    {
        powderParticle.Play();
    }

    void StopSprayPowder()
    {
        powderParticle.Stop();
    }


    void PlayExtinguisherSound(string auidioClipName)
    {
        foreach(AudioClip playClip in extinguisherClip)
        {
            if (playClip.name == auidioClipName)
            {
                audioSource.PlayOneShot(playClip);
            }
        }
    }
}
