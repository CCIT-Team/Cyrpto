using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HItBox : MonoBehaviour
{
    public GameObject[] BreakMon;
    int Breakmon = 0;
    public ParticleSystem[] Dead;
    public bool isHit = false;
    public static bool inHit;
    [HideInInspector]
    public int hitDir = 0;
    public GameObject[] hitbox;
    public GameObject arrow;
    BoxCollider col;
    GameObject breakParts;
    bool hitboxright = false;
    bool hitboxleft = false;
    bool hitboxup = false;
    public bool isbreak = false;
    internal bool colorMatch;

    void Start()
    {

    }

    void Update()
    {
        inHit = isHit;
       
    }

    private void OnEnable()
    {
        if (arrow.name != "AimPoint")
        {
            hitDir = Random.Range(0, 3);
            switch (hitDir)
            {
                case 0:
                    hitbox[0].gameObject.SetActive(true);
                    arrow.transform.Rotate(0, 0, 180);
                    break;
                case 1:
                    hitbox[1].gameObject.SetActive(true);
                    arrow.transform.Rotate(0, 0, 0);
                    break;
                case 2:
                    hitbox[2].gameObject.SetActive(true);
                    arrow.transform.Rotate(0, 0, -90);
                    break;
            }
        }
        else
        {
            col = GetComponent<BoxCollider>();
            col.center = new Vector3(0, 1.1f, col.center.z);
            col.size = new Vector3(0.9f, 2.2f, col.size.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        colorMatch = (tag == "RedEnemy" && other.tag == "Red_Sword") || (tag == "BlueEnemy" && other.tag == "Blue_Sword") ? true : false;
        if(colorMatch == true)
        {
            Debug.Log("HitBOOOOOOOOOOOOOOOOOOOOOOOOOOOOOX");
        }
        else { Debug.Log("DON  HIT"); }
        if (isHit && colorMatch)
        {
            ScoreManager.Instance.Perpect();
            isbreak = true;
            Monbreak();
        }

        if(other.tag == "panj")
        {
            ScoreManager.instance.Miss();
        }
        //else if (isHit && !colorMatch)
        //{
        //    ScoreManager.Instance.Miss();
        //    isbreak = true;
        //    Monbreak();
        //}
        //else if (isHit && ((tag == "far" && other.tag == "Blue_Sword") || (tag == "far" && other.tag == "Red_Sword")))
        //{
        //    ScoreManager.Instance.Miss();
        //    isbreak = true;
        //    Monbreak();
        //}
        //else if(!isHit && Player.transform.position == gameObject.transform.position || inHit && Player.transform.position == gameObject.transform.position)
        //{
        //    ScoreManager.Instance.Miss();
        //}
        //if (isHit && hitboxleft == true & hitboxright == true)
        //{
        //   // ScoreManager.Instance.Great();
        //    isbreak = true;
        //    //Monbreak();
        //}
        //if (isHit && hitboxright == true & hitboxleft == true) 
        //{
        //   // ScoreManager.Instance.Great();
        //    isbreak = true;
        //    //Monbreak();
        //}
        //else if (isHit && hitboxup == true & hitboxright == true)
        //{
        //    ScoreManager.Instance.Good();
        //    isbreak = true;
        //    Monbreak();
        //}
        //else if (isHit && hitboxup == true & hitboxleft == true)
        //{
        //    ScoreManager.Instance.Good();
        //    isbreak = true;
        //    Monbreak();
        //}

    }

    public void Monbreak()
    {
        Breakmon = Random.Range(0, 4);
        switch (Breakmon)
        {
            case 0:
                breakParts = Instantiate(BreakMon[0]);
                breakParts.transform.position = this.gameObject.transform.position + new Vector3(0, 0.2f, 0);
                break;
            case 1:
                breakParts = Instantiate(BreakMon[1]);
                breakParts.transform.position = this.gameObject.transform.position + new Vector3(0, 0.2f, 0);
                break;
            case 2:
                breakParts = Instantiate(BreakMon[2]);
                breakParts.transform.position = this.gameObject.transform.position + new Vector3(0,0.2f,0);
                break;
            case 3:
                breakParts = Instantiate(BreakMon[3]);
                breakParts.transform.position = this.gameObject.transform.position + new Vector3(0, 0.2f, 0);
                break;
        }
        Destroy(gameObject);
    }

}