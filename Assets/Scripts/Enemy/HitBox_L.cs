using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox_L : MonoBehaviour
{
    public HitBox Hit;
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Blue_Sword") || other.CompareTag("Red_Sword"))
    //    {
    //        Debug.Log("Hit");
    //        Hit.isHit = true;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Blue_Sword") || other.CompareTag("Red_Sword"))
            { Hit.isHit = true;  Hit.hl = true; }
    }
}
