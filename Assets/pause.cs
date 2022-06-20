using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public float currenttime = 3f;
    public float cooltime = 0f;
    public Lim_ViveInputRightHandManager rightHandManager;
    public GameObject[] gameObjects;

    private void OnTriggerEnter(Collider other)
    {
        if(gameObjects[0].tag == "bullet")
        {
            Lim_GameManager.Instance.IsPause = false;
        }
        else if(gameObjects[1].tag == "bullet")
        {
            SceneManager.LoadScene("MainScene");
        }
        else if(gameObjects[2].tag == "bullet")
        {
            gameObjects[3].SetActive(true);
        }
    }

}
