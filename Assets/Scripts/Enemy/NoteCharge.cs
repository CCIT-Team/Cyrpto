using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteCharge : MonoBehaviour
{
    public Sprite[] blueArrow;
    public Sprite[] redArrow;
    public Sprite[] AimingPoint;
    Image img;
    Transform playerPos, mechPos;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        mechPos = transform.parent.GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(playerPos.position, mechPos.position);
        switch (name)   //거리에 따른 화살표 변화
        {
            case "Red":
                if(dis > 27)    //거리 확인
                    img.sprite = redArrow[0];   // ⊙⊙⊙⊙
                else if (dis > 21)
                    img.sprite = redArrow[1];   // →⊙⊙⊙
                else if (dis > 15)
                    img.sprite = redArrow[2];   // -→⊙⊙
                else if (dis > 9)
                    img.sprite = redArrow[3];   // --→⊙
                else if (dis > 7)
                    img.sprite = redArrow[4];   //---→
                else if (dis > 4)
                    img.sprite = redArrow[3];   // --→⊙
                else if (dis > 1)
                    img.sprite = redArrow[2];   // -→⊙⊙
                else
                    img.sprite = redArrow[1];   // →⊙⊙⊙
                break;
            case "Blue":
                if (dis > 27)
                    img.sprite = blueArrow[0];  // ⊙⊙⊙⊙
                else if (dis > 21)
                    img.sprite = blueArrow[1];
                else if (dis > 15)
                    img.sprite = blueArrow[2];
                else if (dis > 9)
                    img.sprite = blueArrow[3];
                else if (dis > 7)
                    img.sprite = blueArrow[4];  //---→
                else if (dis > 4)
                    img.sprite = redArrow[3];
                else if (dis > 1)
                    img.sprite = redArrow[2];
                else
                    img.sprite = redArrow[1];   // →⊙⊙⊙
                break;
            case "AimPoint":
                if (dis > 33)
                    img.sprite = AimingPoint[0];
                else if (dis > 27)
                    img.sprite = AimingPoint[1];
                else if (dis > 21)
                    img.sprite = AimingPoint[2];
                else if (dis > 15)
                    img.sprite = AimingPoint[3];
                else if (dis > 13)
                    img.sprite = AimingPoint[4];    // Perfact
                else if (dis > 10)
                    img.sprite = AimingPoint[3];
                else if (dis > 7)
                    img.sprite = AimingPoint[2];
                else
                    img.sprite = AimingPoint[1];
                break;
        }
        //Debug.Log(Vector3.Distance(playerPos.position, mechPos.position));
    }
}
