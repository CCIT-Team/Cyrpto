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
    public Image nimage;
    public Image image;
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5;
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
            nimage.color = new Color(0, 0, 0, 0);
            image.color = new Color(0, 0, 0, 0);
            image1.color = new Color(0, 0, 0, 0);
            image2.color = new Color(0, 0, 0, 0);
            image3.color = new Color(0, 0, 0, 0);
            image4.color = new Color(0, 0, 0, 0);
            image5.color = new Color(0, 0, 0, 0);
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
        switch (ScoreManager.instance.missCount)
        {
            case 0:
                HPbar.fillAmount = 1.0f;
                HPtext.text = "100";
                break;
            case 1:
                HPbar.fillAmount = 0.9f;
                HPtext.text = "90";
                break;
            case 2:
                HPbar.fillAmount = 0.8f;
                HPtext.text = "80";
                break;
            case 3:
                HPbar.fillAmount = 0.7f;
                HPtext.text = "70";
                break;
            case 4:
                HPbar.fillAmount = 0.6f;
                HPtext.text = "60";
                break;
            case 5:
                HPbar.fillAmount = 0.5f;
                HPtext.text = "50";
                break;
            case 6:
                HPbar.fillAmount = 0.4f;
                HPtext.text = "40";
                break;
            case 7:
                HPbar.fillAmount = 0.3f;
                HPtext.text = "30";
                break;
            case 8:
                HPbar.fillAmount = 0.2f;
                HPtext.text = "20";
                break;
            case 9:
                HPbar.fillAmount = 0.1f;
                HPtext.text = "10";
                break;
            case 10:
                HPbar.fillAmount = 0.0f;
                HPtext.text = "0";
                break;
        }
    }
    public void scorefill()
    {

    }
}
