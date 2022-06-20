using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance 
        {
        get 
        {
            return Instance;
        }
    }
    public static GameManager instance = null;

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

    public void GameOver()
    {
        if (hp == 0)
        {
            IsGameOver = true;

            result.SetActive(true);
        }

        
    }
    

}
