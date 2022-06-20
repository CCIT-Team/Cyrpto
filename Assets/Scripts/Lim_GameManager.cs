using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lim_GameManager : MonoBehaviour
{
    public static Lim_GameManager Instance 
        {
        get 
        {
            return Instance;
        }
    }
    public static Lim_GameManager instance = null;

    public int maxHp = 0;

    public int hp = 0;

    public int playtime = 0;

    public bool IsPause = false;

    public bool IsGameOver = false;

    public GameObject result;

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

    private void Update()
    {
        //GameOver();
        Gamepause();
    }

    public void GameOver()
    {
        if (hp == 0)
        {
            IsGameOver = true;

            result.SetActive(true);
        }

        
    }
    public void Gamepause()
    {
        if (IsPause == true)
            Time.timeScale = 0.1f;
        else if(IsPause == false)
            Time.timeScale = 1f;
    }
    

}
