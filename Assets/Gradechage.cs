using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 
public class Gradechage : MonoBehaviour
{
    public Image image;
    public GameObject Gread;
    [Header("Grade")]
    public Sprite[] offsetimage;

    public void OnEnable()
    {
        Chage_image();
    }

    public void Start()
    {
        image = GetComponent<Image>();
    }

    public void Update()
    {
        //Chage_image();
    }

    public void Chage_image() //스코어 매니져랑 연동중
    {
        if(ScoreManager.instance.finalsocreup > 90 && ScoreManager.instance.finalsocreup <= 100)
        {
            image.sprite = offsetimage[0]; //이미지 순서가 빠를 수록 좋은 판정
        }
        else if(ScoreManager.instance.finalsocreup > 80 && ScoreManager.instance.finalsocreup <= 90)
        {
            image.sprite = offsetimage[1];
        }
        else if(ScoreManager.instance.finalsocreup > 60 && ScoreManager.instance.finalsocreup <= 80)
        {
            image.sprite = offsetimage[2];
        }
        else if (ScoreManager.instance.finalsocreup > 50 && ScoreManager.instance.finalsocreup <= 60)
        {
            image.sprite = offsetimage[3];
        }
        else if (ScoreManager.instance.finalsocreup > 30 && ScoreManager.instance.finalsocreup <= 50)
        {
            image.sprite = offsetimage[4];
        }
        else
        {
            image.sprite = offsetimage[5];
        }
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            image.sprite = offsetimage[6];
        }
    }
}