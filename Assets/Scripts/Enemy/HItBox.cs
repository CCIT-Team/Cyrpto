using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HItBox : MonoBehaviour
{
    public GameObject[] BreakMon;
    int Breakmon = 0;
    public ParticleSystem[] Dead;
    public static bool inHit = false;
    public bool hits = inHit;
    int hitDir = 0;
    public GameObject[] hitbox;
    public GameObject arrow;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnEnable()
    {
        if(arrow.name != "AimPoint")
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (inHit && ((tag == "RedEnemy" && other.tag == "Red_Sword")|| (tag == "BlueEnemy" && other.tag == "Blue_Sword")))
        {
            Monbreak();
        }
    }

    public void Monbreak()
    {
        Breakmon = Random.Range(0, 4);
        switch (Breakmon)
        {
            case 0:
                Instantiate(BreakMon[0]);
                break;
            case 1:
                Instantiate(BreakMon[1]);
                break;
            case 2:
                Instantiate(BreakMon[2]);
                break;
            case 3:
                Instantiate(BreakMon[3]);
                break;
        }
        Destroy(this.gameObject, 0.1f);
    }
}