using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HitBox : MonoBehaviour
{
    public static HitBox instance;
    public AudioSource break_sound_audiosorce;
    public AudioClip EnemyBreak;
    public GameObject BreakMon;
    bool isMelee = false;
    public ParticleSystem[] Dead;
    public bool isHit = false;
    [HideInInspector]
    public int hitDir = 0; //L = 1, R = 0, U = 2
    public GameObject[] hitbox;
    public GameObject arrow;
    BoxCollider col;
    GameObject breakParts;
    public bool hr = false;
    public bool hl = false;
    public bool hu = false;
    public bool me = false;
    public bool isbreak = false;
    internal bool colorMatch;

    public bool itdead = false;

    Transform playerPos, mechPos;
    public float dis;
    public NoteCharge note;

    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        mechPos = transform;
    }

    void Update()
    {
        dis = Vector3.Distance(playerPos.position, mechPos.position);
        Jugiment();
        if (itdead)
            Monbreak();
    }

    private void OnEnable()
    {
        if (gameObject.layer == 8 || gameObject.layer == 9)
        {
            isMelee = true;
            hitDir = Random.Range(0, 3);
            switch (hitDir)
            {
                case 0:
                    hitbox[0].gameObject.SetActive(true);
                    hitbox[1].gameObject.SetActive(true);
                    arrow.transform.Rotate(0, 0, 180);
                    break;
                case 1:
                    hitbox[0].gameObject.SetActive(true);
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
            isMelee = false;
            col = GetComponent<BoxCollider>();
            col.center = new Vector3(0, 1.1f, col.center.z);
            col.size = new Vector3(1, 2.2f, col.size.z);
        }
    }

    void Jugiment()
    {
        switch (gameObject.layer)   //거리에 따른 화살표 변화
        {
            case 8:
            case 9:
                if (dis > 15)
                {
                    note.chargeGage = 1;
                    if (isHit && colorMatch)
                    {
                        ScoreManager.Instance.Miss();
                        isHit = false;
                        Monbreak();
                        break;
                    }
                }// -→⊙⊙
                else if (dis > 9.5f)
                {   // --→⊙
                    note.chargeGage = 2;
                    if (isHit && colorMatch)
                    {
                        ScoreManager.Instance.Good();
                        isHit = false;
                        Monbreak();
                        break;
                    }
                }
                else if (dis > 4f)
                {
                    note.chargeGage = 3;
                    if (isHit && colorMatch)
                    {
                        ScoreManager.Instance.Great();
                        isHit = false;
                        Monbreak();
                        break;
                    }
                }
                else if (dis > 1.75f)
                {
                    note.chargeGage = 4;
                    if (isHit && colorMatch)
                    {
                        ScoreManager.Instance.Perpect();
                        isHit = false;
                        Monbreak();
                        break;
                    }
                }
                else if (dis > 0.75f)
                {
                    note.chargeGage = 3;
                    if (isHit && colorMatch)
                    {
                        ScoreManager.Instance.Great();
                        isHit = false;
                        Monbreak();
                        break;
                    }
                }     // -→⊙⊙
                else
                {
                    note.chargeGage = 2;
                    if (isHit && colorMatch)
                    {
                        ScoreManager.Instance.Good();
                        isHit = false;
                        Monbreak();
                        break;
                    }
                };   // →⊙⊙⊙
                break;
            case 10:
                if (dis > 25)
                {
                    note.chargeGage = 0;
                    if (Lim_ViveInputLeftHandManager.isgunhit == true)
                    {
                        ScoreManager.Instance.Miss();
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                        Monbreak();
                        break;
                    }
                }
                else if (dis > 20)
                {
                    note.chargeGage = 1;
                    if (Lim_ViveInputLeftHandManager.isgunhit == true)
                    {
                        ScoreManager.Instance.Miss();
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                        Monbreak();
                        break;
                    }
                }
                else if (dis > 15)
                {
                    note.chargeGage = 2;
                    if (Lim_ViveInputLeftHandManager.isgunhit == true)
                    {
                        ScoreManager.Instance.Good();
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                        Monbreak();
                        break;
                    }
                }
                else if (dis > 10)
                {
                    note.chargeGage = 3;
                    if (Lim_ViveInputLeftHandManager.isgunhit == true)
                    {
                        ScoreManager.Instance.Great();
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                        Monbreak();
                        break;
                    }
                }
                // Perfact
                else if (dis > 5)
                {
                    note.chargeGage = 4;
                    if (Lim_ViveInputLeftHandManager.isgunhit == true)
                    {
                        ScoreManager.Instance.Perpect();
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                        Monbreak();
                        break;
                    }
                }
                else if (dis > 0)
                {
                    note.chargeGage = 3;
                    if (Lim_ViveInputLeftHandManager.isgunhit == true)
                    {
                        ScoreManager.Instance.Great();
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                        Monbreak();
                        break;
                    }
                }
                else
                {
                    note.chargeGage = 2;
                    if (Lim_ViveInputLeftHandManager.isgunhit == true)
                    {
                        ScoreManager.Instance.Good();
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                        Monbreak();
                        break;
                    }
                }
                break;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9 ) { Destroy(hitbox[2]); }
        colorMatch = (gameObject.layer == other.gameObject.layer) ? true : false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "panj")
        {
            ScoreManager.instance.Miss();
        }
    }

    public void Monbreak()
    {
        if(isMelee)
            break_sound_audiosorce.PlayOneShot(EnemyBreak);
        //MechDistroy.Invoke();
        breakParts = Instantiate(BreakMon);
        breakParts.transform.position = this.gameObject.transform.position + new Vector3(0, 0.2f, 0);
        Destroy(gameObject);
    }
}