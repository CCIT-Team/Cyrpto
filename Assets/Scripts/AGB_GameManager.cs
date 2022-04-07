using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    GameObject LCont;
    GameObject RCont;
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
        
    }
    private void GameOver()
    {
        StartCoroutine(CoGameOver());
    }
  

    #region Btn
    public void BtnGamePause()
    {
        Time.timeScale = 0;
        //pauseui ����
    }

    public void BtnContinueGame()
    {
        Debug.Log("�Լ��ϱ�");
        //StartCoroutine(CoConGame());
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

        // ��� ���� �ı� �ִϸ��̼�

        //ui �˾�

    }

    IEnumerator CoConGame()
    {
        //�˾� ������
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1f);
            //ī��Ʈ �ٿ� �̹��� ����
        }


        Time.timeScale = 1;
        
    }
    #endregion
}
