using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMain : MonoBehaviour
{
    public GameObject Title;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blue_Sword")
        {
            Instantiate(Title);
        }
    }
}
