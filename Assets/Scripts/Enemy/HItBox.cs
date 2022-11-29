using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HitBox : MonoBehaviour
{
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

    void Start()
    {
        
    }

    void Update()
    {
        RightDirection();
        if (itdead)
            Monbreak();
    }

    private void OnEnable()
    {
        if (arrow.name != "AimPoint")
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

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Red_Sword" || other.tag == "Blue_Sword") { me = true; }
        colorMatch = (tag == "RedEnemy" && other.tag == "Red_Sword") || (tag == "BlueEnemy" && other.tag == "Blue_Sword") ? true : false;
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

    void RightDirection()
    {
       if(hl == true) { Destroy(hitbox[0]);}
       if(hr == true) { Destroy(hitbox[1]);}
       if(me == true) { Destroy(hitbox[2]);}
    }

    public UnityEvent MechDistroy;
}