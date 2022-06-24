using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Lim_ViveInputManager : MonoBehaviour
{
    public Canvas PlayerUI;
    #region
    public static Lim_ViveInputManager Instance 
    {
        get { return instance; }
        set { }
    }
    #endregion
    public static Lim_ViveInputManager instance = null;

    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        
        DontDestroyOnLoad(gameObject);
        
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            PlayerUI.enabled = false;
        }
        else
        {
            PlayerUI.enabled = true;
        }
    }
}
