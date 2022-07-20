using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleslidesound : MonoBehaviour
{
    public AudioClip sildesound;
    public AudioSource audioSource;
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Title")
        {
            audioSource.PlayOneShot(sildesound);
        }
    }
}
