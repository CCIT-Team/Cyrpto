using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox_Sub : MonoBehaviour
{
    public HItBox Hit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blue_Sword") || other.CompareTag("Red_Sword"))
        {
            Hit.GetComponent<HItBox>().isHit = true;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Blue_Sword") || other.CompareTag("Red_Sword"))
    //    {
    //            HItBox.inHit = true;
    //    }
    //}
}
