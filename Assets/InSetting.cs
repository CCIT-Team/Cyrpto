using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSetting : MonoBehaviour
{
    public GameObject setting;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bule_Sword")
        {
            setting.SetActive(true);
        }
        
    }
}
