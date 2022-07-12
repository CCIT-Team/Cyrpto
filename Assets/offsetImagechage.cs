using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class offsetImagechage : MonoBehaviour
{
    public Image image;

    [Header("Offset")]
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
        switch (ScoreManager.instance.scoreNum)
        {
            case 0:
                image.sprite = offsetimage[0]; //이미지 순서가 빠를 수록 좋은 판정
                break;
            case 1:
                image.sprite = offsetimage[1];
                break;
            case 2:
                image.sprite = offsetimage[2];
                break;
            case 3:
                image.sprite = offsetimage[3];
                break;
        }
    }
}
