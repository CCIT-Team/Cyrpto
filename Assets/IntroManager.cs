using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public GameObject intormanager;

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "chapter1" || SceneManager.GetActiveScene().name == "shoot only" || SceneManager.GetActiveScene().name == "melee only")
        {
            intormanager.SetActive(false);
        }
    }
    
}
