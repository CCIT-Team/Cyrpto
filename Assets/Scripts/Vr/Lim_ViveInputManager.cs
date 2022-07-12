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
    public Image HPbar;
    public Text HPtext;
    public int Exmiss; //--예시 miss 판정

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
        hpbarfill();
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
        else
        {
            maingiude.SetActive(false);
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
            }
            else
            {
                maingiude.SetActive(false);
            }
        }
        else
        {
            maingiude.SetActive(false);
        }
    }

    IEnumerator FindWiating()
    {
        yield return waitForSeconds;
        findMenu = GameObject.Find("MainMenu");
    }

    public void hpbarfill()
    {
        switch (Exmiss)
        {
            case 0:
                HPbar.fillAmount = 1.0f;
                HPtext.text = "100";
                break;
            case 1:
                HPbar.fillAmount = 0.75f;
                HPtext.text = "75";
                break;
            case 2:
                HPbar.fillAmount = 0.5f;
                HPtext.text = "50";
                break;
            case 3:
                HPbar.fillAmount = 0.25f;
                HPtext.text = "25";
                break;
            case 4:
                HPbar.fillAmount = 0.0f;
                HPtext.text = "0";
                break;
        }
    }
    public void scorefill()
    {

    }
}
