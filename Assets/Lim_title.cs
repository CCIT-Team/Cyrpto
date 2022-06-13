using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lim_title : MonoBehaviour
{
    public GameObject titlePrefab;

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Blue_Sword")
        {
            Instantiate(titlePrefab);
            Destroy(gameObject, 0.1f);
        }

    }
}
