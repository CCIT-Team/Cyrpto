using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox_L : MonoBehaviour
{
    public HitBox Hit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9)
        { Hit.isHit = true; Hit.hl = true; }
    }
}