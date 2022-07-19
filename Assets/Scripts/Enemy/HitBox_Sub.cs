using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox_Sub : MonoBehaviour
{
    public HItBox Hit;
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Blue_Sword") || other.CompareTag("Red_Sword"))
    //    {
    //        Debug.Log("Hit");
    //        Hit.isHit = true;
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Blue_Sword") || other.CompareTag("Red_Sword"))
        {
            Debug.Log("Hit");
            Hit.isHit = true;
        }
    }
}
