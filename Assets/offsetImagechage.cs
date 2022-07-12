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

    public void Chage_image() //���ھ� �Ŵ����� ������
    {
        switch (ScoreManager.instance.scoreNum)
        {
            case 0:
                image.sprite = offsetimage[0]; //�̹��� ������ ���� ���� ���� ����
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
