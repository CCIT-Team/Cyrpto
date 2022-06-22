using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public float finalScore;
    public int[] score = new int[] { 0, 0, 0 }; // 0 = per 1 = great 2 = good
    public int scoreNum; // 0 = per 1 = great 2 = good 이걸로 각 판정에 값을 가져와 if문으로 구현하면 될듯?
    public string scorestring;
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
        if (timer[0] <= 0)
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
            default:
                scorestring = "";
                break;

        }
    }
}
