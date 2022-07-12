using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lim_GameManager : MonoBehaviour
{
    #region
    public static Lim_GameManager Instance 
    {
        get { return instance; }
        set{ }
    }
    #endregion
    public static Lim_GameManager instance = null;

    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2.0f);
    public static readonly WaitForSeconds waitForReslut = new WaitForSeconds(5.0f);

    public int maxHp = 0, hp = 0, playtime = 0;

    public bool IsPause = false, IsGameOver = false, IsSetting = false, Isbefore = false;

    public GameObject result, pause, setting, OffSetImage, beforeresult;

    public Image HPbar;

    public Text HPtext, combotext;

    [Header("Fade In Out")]
    public GameObject fade;

    private void Awake()
    {
        if(instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

    }


    public void Update()
    {
        GameOver();
        Gamepause();
        SettingPopup();
    }

    public void GameOver()
    {
        if (hp == 0)
        {
            IsGameOver = true;
            if(IsGameOver == true)
            {
                result.SetActive(true);
                Time.timeScale = 0.01f;
            } 
        }
    }
    public void Gamepause()
    {
        if (IsPause == true)
        {
            pause.SetActive(true);
            Time.timeScale = 0.1f;
        }
        else if (IsPause == false)
        {
            pause.SetActive(false);
            Time.timeScale = 1f;
        }

    }
    
    public void returnscene()
    {
        
        SceneManager.LoadScene("MainScene");

    }

    public void SettingPopup()
    {
        if (IsSetting == true)
        {
            setting.SetActive(true);
            Time.timeScale = 0.1f;
        }
        else if(IsSetting == false)
        {
            setting.SetActive(false);
            Time.timeScale = 1f;
        }
    }


    public void HPmanager()
    {
        HPbar.fillAmount = hp / maxHp;
        HPtext.text = string.Format("{0}", hp);
    }


    public void ResultSet()
    {
        //if(lane.GameEND == true)
        //{
        //    beforeresult.SetActive(true);
        //    Isbefore = true;
        //    if(Isbefore == true)
        //    {
        //        StartCoroutine(beforeReSult());
        //    }
        //}
    }

    IEnumerator beforeReSult()
    {
        yield return waitForReslut;
        result.SetActive(true);


    }
}
