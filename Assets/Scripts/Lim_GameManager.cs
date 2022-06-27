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

    public int maxHp = 0, hp = 0, playtime = 0;

    public bool IsPause = false, IsGameOver = false;

    public GameObject result, pause, setting, OffSetImage;

    public Image HPbar;

    public Text HPtext, combotext;

    [Header("Offset")]
    public Sprite[] offsetimage;
    public float offsettest;

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
        Chage_image();

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
                Debug.Log(Time.timeScale);
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
        setting.SetActive(true);
    }

    public void HPmanager()
    {
        HPbar.fillAmount = hp / maxHp;
        HPtext.text = string.Format("{0}", hp);
    }

    public void Chage_image() //�����Ŵ����� �������ּ���
    {
        switch(offsettest)
        {
            case 0.1f:
                OffSetImage.GetComponent<Image>().sprite = offsetimage[0]; //�̹��� ������ ���� ���� ���� ����
                break;
            case 0.2f:
                OffSetImage.GetComponent<Image>().sprite = offsetimage[1];
                break;
            case 0.3f:
                OffSetImage.GetComponent<Image>().sprite = offsetimage[2];
                break;
            case 0.4f:
                OffSetImage.GetComponent<Image>().sprite = offsetimage[3];
                break;
        }
    }
}
