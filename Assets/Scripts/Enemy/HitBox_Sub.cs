using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox_Sub : MonoBehaviour
{
    public HitBox Hit;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9)
        {
            Hit.isHit = true;
            Destroy(this.gameObject);
        }
    }
}
