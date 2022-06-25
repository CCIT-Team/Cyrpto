using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lim_ViveInputManager : MonoBehaviour
{
    public Canvas PlayerUI;
    public GameObject guide;
    public GameObject maingiude;
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2.5f);
    public GameObject findMenu;
    public bool onfindMenu = false;

    public Lim_ViveInputRightHandManager rightHandManager;

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
        PlayerHud();
        OnGuide();
        OnMainGuide();
    }
    public void PlayerHud()
    {
        if (SceneManager.GetActiveScene().name == "MainScene" || SceneManager.GetActiveScene().name == "LodingScene")
        {
            PlayerUI.enabled = false;
        }
        else
        {
            PlayerUI.enabled = true;
        }
    }

    public void OnGuide()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            if (rightHandManager.rtriggeron == true)
            {
                guide.SetActive(false);
            }
            else
            {
                guide.SetActive(true);
            }
        }
    }

    public void OnMainGuide()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            StartCoroutine(FindWiating());
            if (findMenu.activeSelf == true)
            {
                if (rightHandManager.rtriggeron == true)
                {
                    maingiude.SetActive(true);
                }
                else
                {
                    maingiude.SetActive(false);
                }
            }else
            {
                maingiude.SetActive(false);
            }
        }
    }

    IEnumerator FindWiating()
    {
        yield return waitForSeconds;
        findMenu = GameObject.Find("MainMenu");
    }
}
