using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Gradechage : MonoBehaviour
{
    public Image image;

    [Header("Grade")]
    public Sprite[] offsetimage;

    public void Start()
    {
        image = GetComponent<Image>();
    }

    public void Update()
    {
        Chage_image();
    }

    public void Chage_image() //스코어 매니져랑 연동중
    {
        switch (ScoreManager.instance.finalsocreup)
        {
            case 100:
                image.sprite = offsetimage[0]; //이미지 순서가 빠를 수록 좋은 판정
                break;
            case 80:
                image.sprite = offsetimage[1];
                break;
            case 60:
                image.sprite = offsetimage[2];
                break;
            case 40:
                image.sprite = offsetimage[3];
                break;
            case 30:
                image.sprite = offsetimage[4];
                break;
            default:
                image.sprite = offsetimage[5];
                break;

        }
    }
}