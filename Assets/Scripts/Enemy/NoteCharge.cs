using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteCharge : MonoBehaviour
{
    public Sprite[] blueArrow;
    public Sprite[] redArrow;
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
        switch (name)
        {
            case "Red":
                if(Vector3.Distance(playerPos.position,mechPos.position)>28)
                    img.sprite = redArrow[0];
                else if (Vector3.Distance(playerPos.position, mechPos.position) > 23)
                    img.sprite = redArrow[1];
                else if (Vector3.Distance(playerPos.position, mechPos.position) > 18)
                    img.sprite = redArrow[2];
                else if (Vector3.Distance(playerPos.position, mechPos.position) > 13)
                    img.sprite = redArrow[3];
                else
                    img.sprite = redArrow[4];

                break;
            case "Blue":
                if (Vector3.Distance(playerPos.position, mechPos.position) > 28)
                    img.sprite = blueArrow[0];
                else if (Vector3.Distance(playerPos.position, mechPos.position) > 23)
                    img.sprite = blueArrow[1];
                else if (Vector3.Distance(playerPos.position, mechPos.position) > 18)
                    img.sprite = blueArrow[2];
                else if (Vector3.Distance(playerPos.position, mechPos.position) > 13)
                    img.sprite = blueArrow[3];
                else
                    img.sprite = blueArrow[4];
                break;
        }
        //Debug.Log(Vector3.Distance(playerPos.position, mechPos.position));
    }
}
