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

    public int score = 0;

    public int comdo = 0;

    public int healcomdo = 5;

    public int highscore = 0;

    public bool IsPause = false;

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

    

}
