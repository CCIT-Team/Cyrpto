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
    int hitDir = 0;
    public GameObject[] hitbox;
    public GameObject arrow;
    BoxCollider box;
    GameObject breakParts;

    public bool breaktest = false;

    void Start()
    {

    }

    void Update()
    {
        inHit = isHit;
        if (breaktest)
            Monbreak();
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
            box = GetComponent<BoxCollider>();
            box.center = new Vector3(0,1.1f,box.center.z);
            box.size = new Vector3(0.9f, 2.2f, box.size.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (isHit && ((gameObject.CompareTag("RedEnemy") && other.CompareTag("Red_Sword")) || (gameObject.CompareTag("BlueEnemy") && other.CompareTag("Blue_Sword"))))
        {

            Monbreak();
        }
        if (hitbox[0].CompareTag("Blue_Sword") || hitbox[0].CompareTag("Red_Sword"))
        {
            isHit = true;
        }
        if (hitbox[1].CompareTag("Blue_Sword") || hitbox[1].CompareTag("Red_Sword"))
        {
            isHit = true;
        }
        if (hitbox[2].CompareTag("Blue_Sword") || hitbox[2].CompareTag("Red_Sword"))
        {
            isHit = true;
        }
    }

    public void Monbreak()
    {
        Breakmon = Random.Range(0, 4);
        switch (Breakmon)
        {
            case 0:
                breakParts = Instantiate(BreakMon[0]);
                breakParts.transform.position = this.gameObject.transform.position;
                break;
            case 1:
                breakParts = Instantiate(BreakMon[1]);
                breakParts.transform.position = this.gameObject.transform.position;
                break;
            case 2:
                breakParts = Instantiate(BreakMon[2]);
                breakParts.transform.position = this.gameObject.transform.position;
                break;
            case 3:
                breakParts = Instantiate(BreakMon[3]);
                breakParts.transform.position = this.gameObject.transform.position;
                break;
        }
        Destroy(this.gameObject);
    }

}