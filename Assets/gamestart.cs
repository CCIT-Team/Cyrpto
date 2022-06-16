using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gamestart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blue_Sword")
        {
            SceneManager.LoadScene("Game_Scene");
        }
    }
}
