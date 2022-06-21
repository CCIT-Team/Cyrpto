using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Blue_Sword")
        {
            Lim_GameManager.Instance.IsPause = false;
        }
    }

}
