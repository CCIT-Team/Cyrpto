using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reture : MonoBehaviour
{
    private void OnTriggerEnter(Collider ture)
    {
        if(ture.tag == "Bule_Sword")
            SceneManager.LoadScene("MainScene");
        Debug.Log("LoadMainScene");
    }
}
