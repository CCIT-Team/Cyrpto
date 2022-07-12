using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox_Sub : MonoBehaviour
{
    public HItBox Hit;
    bool isend = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Blue_Sword") || other.CompareTag("Red_Sword"))
        {
            // HItBox.inHit = true;
            isend = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Blue_Sword") || other.CompareTag("Red_Sword"))
        {
            if (isend == false)
            {
                HItBox.inHit = true;
                isend = true;
            }
        }
    }
}
