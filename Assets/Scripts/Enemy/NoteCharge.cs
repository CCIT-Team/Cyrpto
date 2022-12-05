using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteCharge : MonoBehaviour
{
    public Sprite[] blueArrow;
    public Sprite[] redArrow;
    public Sprite[] AimingPoint;
    public Image arrow;

    public int chargeGage;


    void Update()
    {
        switch(gameObject.layer)
        {
            case 8:
                arrow.name = "Red";
                break;
            case 9:
                arrow.name = "Blue";
                break;
            case 10:
                arrow.name = "AimPoint";
                break;
        }
        switch (gameObject.layer)   //거리에 따른 화살표 변화
        {
            case 8:
                arrow.sprite = redArrow[chargeGage];
                break;
            case 9:
                arrow.sprite = blueArrow[chargeGage];
                break;
            case 10:
                arrow.sprite = AimingPoint[chargeGage];
                break;
        }
    }
}
