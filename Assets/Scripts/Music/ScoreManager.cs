using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public float finalScore;
    public int[] score = new int[] {0,0,0}; // 0 = per 1 = great 2 = good
    public int scoreNum; // 0 = per 1 = great 2 = good �̰ɷ� �� ������ ���� ������ if������ �����ϸ� �ɵ�?
    public int grade = 0;// 0 = s 1 = a 2 = b ......
    public int comboScore;
    public float[] timer = { 1.5f, 1.5f, 1.5f };

    void Start()
    {
        Instance = this;
        comboScore = 0;
    }

    public void Hit()
    {
        comboScore += 1;      
    }

    public void Miss()
    {
        comboScore = 0;
      
    }
    public void Perpect()
    {
        scoreNum = 0;
        score[0] += 100;
        timer[0] -= Time.deltaTime;
        if(timer[0] <= 0)
        {
            scoreNum = 4;
        }
        timer[0] = 1.5f;
    }
    public void Great()
    {
        scoreNum = 1;
        score[1] += 50;
        timer[0] -= Time.deltaTime;
        if (timer[1] <= 0)
        {
            scoreNum = 5;
        }
        timer[1] = 1.5f;
    }
    public void Good()
    {
        scoreNum = 3;
        score[2] += 20;
        timer[0] -= Time.deltaTime;
        if (timer[2] <= 0)
        {
            scoreNum = 6;
        }
        timer[2] = 1.5f;
    }
    public void FinalResult()
    {
        finalScore = score[0] + score[1] + score[2];
        switch(finalScore)
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
    }
    void Update()
    {
       
    }
}
