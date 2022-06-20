using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resume : MonoBehaviour
{
    public Lim_ViveInputRightHandManager rightHandManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bullet")
        {
            Lim_GameManager.Instance.IsPause = false;
        }
    }
}
