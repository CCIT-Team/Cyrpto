//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.XR.Interaction.Toolkit;

//public class AGB_GameManager : MonoBehaviour
//{
//    #region Variable

//    [SerializeField]
//    private int _maxHp = 0;
//    [SerializeField]
//    private int _hp = 0;
//    [SerializeField]
//    private int _score = 0;
//    [SerializeField]
//    private int _combo = 0;
//    [SerializeField]
//    private int _healCombo = 5;

//    private float _gameOverTime = 1f;
//    public bool _isPause = false;


//    public GameObject LCont;
//    public GameObject RCont;

//    //lay
//    XRInteractorLineVisual Llay;
//    XRInteractorLineVisual Rlay;
//    //ui
//    GameObject RMenu;
//    GameObject LMenu;
//    GameObject Sword;
//    public GameObject CountText;
//    Text CountTexts;
//    bool _isContText = false;
//    string _Cunt;
    
//    #endregion

//    #region intance

//    public static AGB_GameManager _inst = null;
//    private static readonly object key = new object();

  
//    private void Awake()
//    {
//        _inst = this;
//    }
//    #endregion

//    #region GetSet
//    public int Hp
//    {
//        get { return _hp; }
//        set
//        {
//            if (value != 0)
//                _hp = value;
//            else
//                _hp = 0;
//        }
//    }


//    public int Scoore
//    {
//        get { return _score; }
//        set { _score = value; }
//    }
//    public int Combo
//    {
//        get { return _combo; }
//        set
//        {
//            _combo = value;
//            if (_maxHp > Hp)
//            {
//                if ((value %= _healCombo) == 0)
//                    Hp++;
//            }
//        }
//    }
//    #endregion


//    private void Start()
//    {

//        CountTexts = CountText.GetComponent<Text>();
//        Llay = LCont.transform.GetComponent<XRInteractorLineVisual>();
//        Rlay = RCont.transform.GetComponent<XRInteractorLineVisual>();
//        RMenu = RCont.transform.GetChild(0).gameObject;
//        LMenu = LCont.transform.GetChild(0).gameObject;
//        Sword = RCont.transform.GetChild(1).gameObject;
//        Llay.lineLength = 0;
//        Llay.invalidColorGradient.alphaKeys[0].alpha = 0;
//        Rlay.invalidColorGradient.alphaKeys[0].alpha = 0;
//        Rlay.lineLength = 0;

//    }
//    private void GameOver()
//    {
//        StartCoroutine(CoGameOver());
//    }
//    private void Update()
//    {
//        if (_isContText)
//            CountTexts.text = _Cunt;

//    }

//    #region Btn
//    /// <summary>
//    /// ????????
//    /// </summary>
//    /// <param name="i">0 == Right ,1==Left </param>
//    /// 
//    public void BtnGamePause(int i)
//    {


//        //Time.timeScale = 0;
//        if (i == 0)
//        {
//            Llay.lineLength = 1;
//            Sword.SetActive(false);
//            RMenu.SetActive(true);
//        }
//        else
//        {
//            Rlay.lineLength = 1;
//            Sword.SetActive(false);
//            LMenu.SetActive(true);
//        }

//    }

//    public void BtnContinueGame(int i)
//    {
//        Llay.lineLength = 0;
//        Rlay.lineLength = 0;
//        StartCoroutine(CoConGame(i));
//    }



//    #endregion

//    #region Corutin

//    IEnumerator CoGameOver()
//    {
//        while (_gameOverTime > 0)
//        {
//            Time.timeScale = _gameOverTime;
//            yield return new WaitForSeconds(0.2f);
//            _gameOverTime -= 0.1f;
//        }

//        // ???? ?????? ???? ??????????

//        //ui ????

//    }

//    IEnumerator CoConGame(int j)
//    {
//        switch (j)
//        {
//            case 0:
//                RMenu.SetActive(false);
//                break;
//            default:
//                LMenu.SetActive(false);
//                break;
//        }
        
//        _isContText = true;
//        StartCoroutine(CountDown());
//        //???? ??????
//        for (int i = 3; i > 0; i--)
//        {
//            _Cunt = Convert.ToString(i);
//            yield return new WaitForSeconds(1f);
//            CountText.transform.localPosition = new Vector3(0, 0, 0);
//            //?????? ???? ?????? ????
         
//        }

//        CountTexts.text = "";
//        _isContText = false;
//        _isPause = false;
//        //Time.timeScale = 1;

//    }
//    IEnumerator CountDown()
//    {
//        float z = CountText.transform.localPosition.z;
//        while (_isContText)
//        {
//            z = CountText.transform.localPosition.z;
//            CountText.transform.localPosition = new Vector3(0, 0, z += 5f);
//            yield return new WaitForSeconds(0.0001f);
//        }
//        CountText.transform.localPosition = new Vector3(0, 0, 0);

//    }
//    #endregion
//}
