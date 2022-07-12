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
    // �������� ������ ���������� ��, �� ������ ����, �� ������ ����, �޺��� ����, ������ ���� �̻��̶�� PASS �����ϰ� BOOL �� �ϳ�, ������ ���, ���ھ� ��� �� �ۼ�Ʈ ����?
    public float finalScore;
    public int[] score = new int[] { 0, 0, 0 }; // 0 = per 1 = great 2 = good
    public int scoreNum = 4; // 0 = per 1 = great 2 = good �̰ɷ� �� ������ ���� ������ if������ �����ϸ� �ɵ�?
    public string scorestring = "";
    public int grade = 0;// 0 = s 1 = a 2 = b ......
    public float finalScorehave;
    public int finalsocreup; //�ݿø��� ���ؼ� ����ϴ� �����
    public float finalSocorefloat;

    public int x;//------------------------------------����� �𸣴� ��(��� ��Ʈ�� ��)

    [Header("TEXT ����")] //��� �κа� ����
    public Text Perpecttext;
    public Text GreatText;
    public Text GoodText;
    public Text MissText;
    public Text Resultscore;
    public Image passimage;
    public Text passText;

    [Header("�� Count")]
    public int peroectCount;
    public int greatCount;
    public int goodCount;
    public int missCount;

    [Header("COMBO")]
    public int combocount;

    public Text totalScore;

    //������ ���� �Ķ���Ϳ� �̹����� ���ӸŴ����� ������ ����
    //���̺���ǲ�Ŵ����� ���� �̽������� ü���� ���̴� �ڵ尡 ����
    //���ο��� ����Ǿ� �ֱ� ������ �Լ��ȿ� ���븸 �����Ͽ� ����ϸ� �ɵ� 

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
        allnoteCount = peroectCount + greatCount + missCount + goodCount; //��� ��� ����

        finalScorehave = (finalScorehave / x) * 100; //------�ۼ�Ʈ

        finalSocorefloat = (finalScorehave / x) * 0.01f;

        passimage.fillAmount = finalSocorefloat;

        finalsocreup = Mathf.RoundToInt(finalScorehave) / allnoteCount;


        Resultscore.text = finalsocreup.ToString(); // ��� �ۼ�Ʈ
        passText.text = finalsocreup.ToString();


    }
    void Update()
    {
        FinalResult();
        percentScore();
    }
}
