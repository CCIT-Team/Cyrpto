using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region
    public static ScoreManager Instance {
        get { return instance; }
        set { }
    }
    #endregion
    public static ScoreManager instance = null;
    // 판정으로 무엇을 가져오는지 모름, 각 판정의 개수, 각 판정의 점수, 콤보의 배율, 점수가 일정 이상이라면 PASS 가능하게 BOOL 값 하나, 점수별 등급, 스코어 결과 왜 퍼센트 인지?
    public float finalScore;
    public int[] score = new int[] { 0, 0, 0 }; // 0 = per 1 = great 2 = good
    public int scoreNum = 4; // 0 = per 1 = great 2 = good 이걸로 각 판정에 값을 가져와 if문으로 구현하면 될듯?
    public string scorestring = "";
    public int grade = 0;// 0 = s 1 = a 2 = b ......
    public float finalScorehave;
    public int finalsocreup; //반올림을 위해서 사용하는 결과값
    public float finalSocorefloat;

    public int x;//------------------------------------현재는 모르는 값(모든 노트의 수)

    [Header("TEXT 판정")] //결과 부분과 연동
    public Text Perpecttext;
    public Text GreatText;
    public Text GoodText;
    public Text MissText;
    public Text Resultscore;
    public Image passimage;
    public Text passText;

    [Header("각 Count")]
    public int peroectCount;
    public int greatCount;
    public int goodCount;
    public int missCount;

    [Header("COMBO")]
    public int combocount;

    public Text totalScore;

    //판정에 대한 파라미터와 이미지는 게임매니저가 가지고 있음
    //바이브인풋매니져에 예시 미스판정시 체력이 까이는 코드가 있음
    //레인에서 선언되어 있기 때문에 함수안에 내용만 수정하여 사용하면 될듯 

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
        combocount = 0; peroectCount = 0; greatCount = 0; goodCount = 0; missCount = 0;
    }

    public void Hit()
    {
        combocount += 1;
    }

    public void Miss()
    {
        combocount = 0;
        scoreNum = 3;
        missCount++;
        MissText.text = missCount.ToString();
    }
    public void Perpect()
    {
        scoreNum = 0;
        score[0] += 100;
        peroectCount++;
        Perpecttext.text = peroectCount.ToString();

    }
    public void Great()
    {
        scoreNum = 1;
        score[1] += 50;
        greatCount++;
        GreatText.text = greatCount.ToString();

    }
    public void Good()
    {
        scoreNum = 2;
        score[2] += 20;
        goodCount++;
        GoodText.text = goodCount.ToString();
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
        if (combocount >= 20 && combocount < 40) { finalScore *= 1.1f; };
        if (combocount >= 40 && combocount < 80) { finalScore *= 1.2f; };
        if (combocount >= 80 && combocount < 159) { finalScore *= 1.3f; };
        if (combocount >= 160) { finalScore *= 1.4f; };
    }

    public void percentScore()
    {
        finalScorehave = finalScore;
        int allnoteCount = 0;
        allnoteCount = peroectCount + greatCount + missCount + goodCount; //모든 노드 개수

        finalScorehave = (finalScorehave / x) * 100; //------퍼센트

        finalSocorefloat = (finalScorehave / x) * 0.01f;

        passimage.fillAmount = finalSocorefloat;

        finalsocreup = Mathf.RoundToInt(finalScorehave) / allnoteCount;


        Resultscore.text = finalsocreup.ToString(); // 결과 퍼센트
        passText.text = finalsocreup.ToString();


    }
    void Update()
    {
        FinalResult();
        percentScore();
    }
}
