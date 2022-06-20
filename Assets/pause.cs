using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject[] gameObjects;

    private void OnTriggerEnter(Collider other)
    {
        if(gameObjects[0].tag == "bullet")
        {
            Lim_GameManager.Instance.IsPause = false;
            Debug.Log("111");
        }
        else if(gameObjects[1].tag == "bullet")
        {
            SceneManager.LoadScene("MainScene");
            Debug.Log("222");
        }
        else if(gameObjects[2].tag == "bullet")
        {
            gameObjects[3].SetActive(true);
            Debug.Log("333");
        }
    }

}
