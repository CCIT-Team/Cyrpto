using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteCharge : MonoBehaviour
{
    public HItBox hitbox;
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
                if (dis > 20.5f)
                {
                    img.sprite = redArrow[0];
                }// →⊙⊙⊙
                else if (dis > 15)
                {
                    img.sprite = redArrow[1];
                    if (hitbox.isHit && hitbox.colorMatch)
                    {
                        ScoreManager.Instance.Miss();
                        hitbox.isHit = false;
                        hitbox.Monbreak();
                        break;
                    }
                }// -→⊙⊙
                else if (dis > 9.5f)
                {
                    img.sprite = redArrow[2];   // --→⊙
                    if (hitbox.isHit && hitbox.colorMatch)
                    {
                        ScoreManager.Instance.Good();
                        hitbox.isHit = false;
                        hitbox.Monbreak();
                        break;
                    }
                }
                else if (dis > 4f)
                {
                    img.sprite = redArrow[3];   // --→⊙
                    if (hitbox.isHit && hitbox.colorMatch)
                    {
                        ScoreManager.Instance.Great();
                        hitbox.isHit = false;
                        hitbox.Monbreak();
                        break;
                    }
                }
                else if (dis > 1.75f)
                {
                    img.sprite = redArrow[4];   //---→
                    if (hitbox.isHit && hitbox.colorMatch)
                    {
                        ScoreManager.Instance.Perpect();
                        hitbox.isHit = false;
                        hitbox.Monbreak();
                        break;
                    }
                }
                else if (dis > 0.75f)
                {
                    img.sprite = redArrow[3];
                    if (hitbox.isHit && hitbox.colorMatch)
                    {
                        ScoreManager.Instance.Great();
                        hitbox.isHit = false;
                        hitbox.Monbreak();
                        break;
                    }
                }     // -→⊙⊙
                else
                {
                    img.sprite = redArrow[2];
                    if (hitbox.isHit && hitbox.colorMatch)
                    {
                        ScoreManager.Instance.Good();
                        hitbox.isHit = false;
                        hitbox.Monbreak();
                        break;
                    }
                };   // →⊙⊙⊙
                break;
            case "Blue":
                if (dis > 20.5f)
                    img.sprite = blueArrow[0];
                else if (dis > 15)
                {
                    img.sprite = blueArrow[1];
                    if (hitbox.isHit && hitbox.colorMatch)
                    {
                        ScoreManager.Instance.Miss();
                        hitbox.isHit = false;
                        hitbox.Monbreak();
                        break;
                    }
                }
                else if (dis > 9.5)
                {
                    img.sprite = blueArrow[2];   // --→⊙
                    if (hitbox.isHit && hitbox.colorMatch)
                    {
                        ScoreManager.Instance.Good();
                        hitbox.isHit = false;
                        hitbox.Monbreak();
                        break;
                    }
                }
                else if (dis > 4)
                {
                    img.sprite = blueArrow[3];
                    if (hitbox.isHit && hitbox.colorMatch)
                    {
                        ScoreManager.Instance.Great();
                        hitbox.isHit = false;
                        hitbox.Monbreak();
                        break;
                    }// --→⊙
                }
                else if (dis > 1.75f)
                {
                    img.sprite = blueArrow[4];
                    if (hitbox.isHit && hitbox.colorMatch)
                    {
                        ScoreManager.Instance.Perpect();
                        hitbox.isHit = false;
                        hitbox.Monbreak();
                        break;
                    }//---→
                }
                else if (dis > 0.75f)
                {
                    img.sprite = blueArrow[3];
                    if (hitbox.isHit && hitbox.colorMatch)
                    {
                        ScoreManager.Instance.Great();
                        hitbox.isHit = false;
                        hitbox.Monbreak();
                        break;
                    }
                }
                else
                {
                    img.sprite = blueArrow[2];
                    if (hitbox.isHit && hitbox.colorMatch)
                    {
                        ScoreManager.Instance.Good();
                        hitbox.isHit = false;
                        hitbox.Monbreak();
                        break;
                    }
                }  // →⊙⊙⊙

                break;
            case "AimPoint":
                if (dis > 25)
                {
                    img.sprite = AimingPoint[0];
                    if (Lim_ViveInputLeftHandManager.isgunhit == true)
                    {
                        ScoreManager.Instance.Miss();
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                        break;
                    }
                }
                else if (dis > 20)
                {
                    img.sprite = AimingPoint[1];
                    if (Lim_ViveInputLeftHandManager.isgunhit == true)
                    {
                        ScoreManager.Instance.Miss();
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                        break;
                    }
                }
                else if (dis > 15)
                {
                    img.sprite = AimingPoint[2];
                    if (Lim_ViveInputLeftHandManager.isgunhit == true)
                    {
                        ScoreManager.Instance.Good();
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                        break;
                    }
                }
                else if (dis > 10)
                {
                    img.sprite = AimingPoint[3];
                    if (Lim_ViveInputLeftHandManager.isgunhit == true)
                    {
                        ScoreManager.Instance.Great();
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                        break;
                    }
                }
                // Perfact
                else if (dis > 5)
                {
                    img.sprite = AimingPoint[4];
                    if (Lim_ViveInputLeftHandManager.isgunhit == true)
                    {
                        ScoreManager.Instance.Perpect();
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                        break;
                    }
                }
                else if (dis > 1)
                {
                    img.sprite = AimingPoint[3];
                    if (Lim_ViveInputLeftHandManager.isgunhit == true)
                    {
                        ScoreManager.Instance.Great();
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                        break;
                    }
                }
                else
                {
                    img.sprite = AimingPoint[2];
                    if (Lim_ViveInputLeftHandManager.isgunhit == true)
                    {
                        ScoreManager.Instance.Good();
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                        break;
                    }
                }
                break;
        }
    }
}
