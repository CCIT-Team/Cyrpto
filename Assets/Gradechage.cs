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

    public void Chage_image() //���ھ� �Ŵ����� ������
    {
        switch (ScoreManager.instance.finalScore)
        {
            case 1000:
                image.sprite = offsetimage[0]; //�̹��� ������ ���� ���� ���� ����
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