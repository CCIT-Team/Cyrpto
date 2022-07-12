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
        switch (name)
        {
            case "Red":
                if(dis > 26)
                    img.sprite = redArrow[0];
                else if (dis > 20)
                    img.sprite = redArrow[1];
                else if (dis > 14)
                    img.sprite = redArrow[2];
                else if (dis > 8)
                    img.sprite = redArrow[3];
                else
                    img.sprite = redArrow[4];
                break;
            case "Blue":
                if (dis > 26)
                    img.sprite = blueArrow[0];
                else if (dis > 20)
                    img.sprite = blueArrow[1];
                else if (dis > 14)
                    img.sprite = blueArrow[2];
                else if (dis > 8)
                    img.sprite = blueArrow[3];
                else
                    img.sprite = blueArrow[4];
                break;
            case "AimPoint":
                if (dis > 32)
                    img.sprite = AimingPoint[0];
                else if (dis > 26)
                    img.sprite = AimingPoint[1];
                else if (dis > 20)
                    img.sprite = AimingPoint[2];
                else if (dis > 14)
                    img.sprite = AimingPoint[3];
                else
                    img.sprite = AimingPoint[4];
                break;
        }
        //Debug.Log(Vector3.Distance(playerPos.position, mechPos.position));
    }
}
