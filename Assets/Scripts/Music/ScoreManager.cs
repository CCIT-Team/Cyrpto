using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region
    public static ScoreManager Instance {
        get { return instance; }
        set { }
    }
    #endregion
    public static ScoreManager instance = null;

    public float finalScore;
    public int[] score = new int[] { 0, 0, 0 }; // 0 = per 1 = great 2 = good
    public int scoreNum = 4; // 0 = per 1 = great 2 = good �̰ɷ� �� ������ ���� ������ if������ �����ϸ� �ɵ�?
    public string scorestring = "";
    public int grade = 0;// 0 = s 1 = a 2 = b ......
    public int comboScore = 0;

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
    void Start()
    {
        comboScore = 0;
    }

    public void Hit()
    {
        comboScore += 1;
    }

    public void Miss()
    {
        comboScore = 0;
        scoreNum = 3; 
    }
    public void Perpect()
    {
        scoreNum = 0;
        score[0] += 100;

    }
    public void Great()
    {
        scoreNum = 1;
        score[1] += 50;

    }
    public void Good()
    {
        scoreNum = 2;
        score[2] += 20;

    }
    public void FinalResult()
    {
        finalScore = score[0] + score[1] + score[2];
        switch (finalScore)
        {
            case 1000:
                grade = 0;
                break;
            case 900:
                grade = 1;
                break;
            case 800:
                grade = 2;
                break;
            case 700:
                grade = 3;
                break;
        }
        if (comboScore >= 20 && comboScore < 40) { finalScore *= 1.1f; };
        if (comboScore >= 40 && comboScore < 80) { finalScore *= 1.2f; };
        if (comboScore >= 80 && comboScore < 159) { finalScore *= 1.3f; };
        if (comboScore >= 160) { finalScore *= 1.4f; };
    }
    void Update()
    {
        switch (scoreNum)
        {
            case 0:
                scorestring = "Perpect";
                break;
            case 1:
                scorestring = "Great";
                break;
            case 2:
                scorestring = "Good";
                break;
            case 3:
                scorestring = "Miss";
                break;
            default:
                scorestring = "";
                break;

        }
    }
}
