using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordsound : MonoBehaviour
{
    public AudioClip close;
    public AudioSource closeSource;
    public static bool isbluecut = false;

    private void Start()
    {
        closeSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<HItBox>().isbreak)
        {
            closeSource.PlayOneShot(close);
        }
    }
}
