using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public int maxHp = 0;

    public int hp = 0;

    public int playtime = 0;

    public bool IsPause = false;

    public bool IsGameOver = false;

    public GameObject result;

    public GameObject pause;

    public GameObject setting;

    public List<GameObject> text = new List<GameObject>();

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
     

}
