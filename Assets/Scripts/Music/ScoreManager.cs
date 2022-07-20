using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public int allnoteCount = 0;

    [Header("COMBO")]
    public Text combotext;
    public int combocount;

    public Text totalScore;

    [Header("Result")]
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(0.01f);
    public static readonly WaitForSeconds waitForSeconds1 = new WaitForSeconds(4f);
    public GameObject resultwindow;

    [Header("fade")]
    public Image image;
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5;

    public bool gameend;
    AudioSource audioSource;
    AudioClip audioClip;

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
        audioSource = Lim_GameManager.instance.audioSource;
        audioClip = Lim_GameManager.instance.resultsound;
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
        Hit();
        scoreNum = 0;
        score[0] += 100;
        peroectCount++;
        Perpecttext.text = peroectCount.ToString();

    }
    public void Great()
    {
        Hit();
        scoreNum = 1;
        score[1] += 50;
        greatCount++;
        GreatText.text = greatCount.ToString();

    }
    public void Good()
    {
        Hit();
        scoreNum = 2;
        score[2] += 20;
        goodCount++;
        GoodText.text = goodCount.ToString();
    }
    public void FinalResult()
    {
        finalScore = score[0] + score[1] + score[2];

        if (combocount >= 20 && combocount < 40) { finalScore *= 1.1f; };
        if (combocount >= 40 && combocount < 80) { finalScore *= 1.2f; };
        if (combocount >= 80 && combocount < 159) { finalScore *= 1.3f; };
        if (combocount >= 160) { finalScore *= 1.4f; };
    }

    public void percentScore()
    {
        finalScorehave = finalScore;
        allnoteCount = peroectCount + greatCount + missCount + goodCount; //모든 노드 개수

        finalScorehave = (finalScorehave / 99) * 100; //------퍼센트

        finalSocorefloat = (finalScorehave / 99) * 0.01f;

        passimage.fillAmount = finalSocorefloat;

        finalsocreup = Mathf.RoundToInt(finalScorehave) / 99;

        float a = Mathf.Clamp(finalsocreup, 0, 100);
        Resultscore.text = a.ToString(); // 결과 퍼센트
        passText.text = a.ToString();

        combotext.text = "" + ScoreManager.Instance.combocount;
    }
    void Update()
    {
        percentScore();
        FinalResult();
        GameEnd();
    }

    public void GameEnd()
    {
        if (missCount == 10) //------------------------------------------------------------------- 4로 변경하면 끝
        {
            gameend = true;
            resluton();
        }
        else 
        { gameend = false; }
        if (allnoteCount == 99 && gameend == false)
        {
            gameend = true;
            resluton();
        }
    }

    public void resluton()
    {

        StartCoroutine(waitfade());
        StartCoroutine(faderesult());

    }
    IEnumerator waitfade()
    {
        yield return waitForSeconds1;
        resultwindow.SetActive(true);
        audioSource.PlayOneShot(audioClip);

    }

    IEnumerator faderesult()
    {
        float fadecount = 0;
        while (fadecount < 1.0f)
        {
            fadecount += 0.01f;
            yield return waitForSeconds;
            image.color = new Color(0, 0, 0, fadecount);
            image1.color = new Color(0, 0, 0, fadecount);
            image2.color = new Color(0, 0, 0, fadecount);
            image3.color = new Color(0, 0, 0, fadecount);
            image4.color = new Color(0, 0, 0, fadecount);
            image5.color = new Color(0, 0, 0, fadecount);


        }
    }
}
