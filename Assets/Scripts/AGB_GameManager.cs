using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class AGB_GameManager : MonoBehaviour
{
    #region Variable

    [SerializeField]
    private int _maxHp = 0;
    [SerializeField]
    private int _hp = 0;
    [SerializeField]
    private int _score = 0;
    [SerializeField]
    private int _combo = 0;
    [SerializeField]
    private int _healCombo = 5;

    private float _gameOverTime = 1f;



    public GameObject LCont;
    public GameObject RCont;

    //lay
    XRInteractorLineVisual Llay;
    XRInteractorLineVisual Rlay;
    //ui
    GameObject RMenu;
    GameObject LMenu;
    GameObject Sword;
    public GameObject CountText;
    Text CountTexts;
    bool _isContText;
    #endregion

    #region intance

    private static AGB_GameManager _inst = null;
    private static readonly object key = new object();

    public static AGB_GameManager Instance
    {
        get
        {
            lock (key)
            {
                if (_inst == null)
                {
                    _inst = new AGB_GameManager();

                }
                return _inst;
            }
        }
    }
    #endregion

    #region GetSet
    public int Hp
    {
        get { return _hp; }
        set
        {
            if (value != 0)
                _hp = value;
            else
                _hp = 0;
        }
    }


    public int Scoore
    {
        get { return _score; }
        set { _score = value; }
    }
    public int Combo
    {
        get { return _combo; }
        set
        {
            _combo = value;
            if(_maxHp > Hp)
            {
                if ((value %= _healCombo) == 0)
                    Hp++;
            }
        }
    }
    #endregion


    private void Start()
    {
      
        Llay = LCont.transform.GetComponent<XRInteractorLineVisual>();
        Rlay = RCont.transform.GetComponent<XRInteractorLineVisual>();
        RMenu = RCont.transform.GetChild(0).gameObject;
        LMenu = LCont.transform.GetChild(0).gameObject;
        Sword = RCont.transform.GetChild(1).gameObject;
        Llay.lineLength = 0;
        Llay.invalidColorGradient.alphaKeys[0].alpha = 0;
        Rlay.invalidColorGradient.alphaKeys[0].alpha = 0;
        Rlay.lineLength = 0;

    }
    private void GameOver()
    {
        StartCoroutine(CoGameOver());
    }
  

    #region Btn
    /// <summary>
    /// 중지버튼
    /// </summary>
    /// <param name="i">0 == Right ,1==Left </param>
    /// 
    public void BtnGamePause(int i)
    {

        Llay = LCont.transform.GetComponent<XRInteractorLineVisual>();
        Rlay = RCont.transform.GetComponent<XRInteractorLineVisual>();
        Time.timeScale = 0;
        if(i==0)
        {
            Llay.lineLength=1;
            Sword.SetActive(false);
            RMenu.SetActive(true);
        }
        else
        {
            Rlay.lineLength = 1;
            Sword.SetActive(false);
            LMenu.SetActive(true);
        }
     
    }

    public void BtnContinueGame()
    {
        Llay.lineLength = 0;
        Rlay.lineLength = 0;
        StartCoroutine(CoConGame());
    }

 

    #endregion

    #region Corutin

    IEnumerator CoGameOver()
    {
        while (_gameOverTime > 0)
        {
            Time.timeScale = _gameOverTime;
            yield return new WaitForSeconds(0.2f);
            _gameOverTime -= 0.1f;
        }

        // 모든 몬스터 파괴 애니메이션

        //ui 팝업

    }

    IEnumerator CoConGame()
    {

        StartCoroutine(CountDown());
        //팝업 내리기
        for (int i = 3; i < 0; i--)
        {
            CountTexts.text = Convert.ToString(i);
            yield return new WaitForSeconds(1f);
            CountText.transform.position = new Vector3(0, 0, 0);
            //카운트 다운 이미지 변경
        }

        CountTexts.text = "";
        _isContText = false;
        Time.timeScale = 1;
        
    }
    IEnumerator CountDown()
    {
        float x;
        while(_isContText)
        {
            x = CountText.transform.position.x;
            CountText.transform.position = new Vector3(x -= 0.2f, 0, 0);
               yield return new WaitForSeconds(0.1f);
        }
        CountText.transform.position = new Vector3(0, 0, 0);
        _isContText = true;
    }
    #endregion
}
