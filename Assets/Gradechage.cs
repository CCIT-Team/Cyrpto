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
        switch (ScoreManager.instance.finalScore)
        {
            case 1000:
                image.sprite = offsetimage[0]; //이미지 순서가 빠를 수록 좋은 판정
                break;
            case 800:
                image.sprite = offsetimage[1];
                break;
            case 600:
                image.sprite = offsetimage[2];
                break;
            case 400:
                image.sprite = offsetimage[3];
                break;
            case 200:
                image.sprite = offsetimage[4];
                break;

        }
    }
}