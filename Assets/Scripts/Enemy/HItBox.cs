using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HItBox : MonoBehaviour
{
    string typeMatch;
    public bool inHit = false;
    int hitDir = 0;
    public GameObject[] hitbox;
    public GameObject arrow;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(inHit&&other.tag.Substring(0,2)==this.tag.Substring(0, 2))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        hitDir = Random.Range(0, 2);
        switch(hitDir)
        {
            case 0:
                hitbox[0].gameObject.SetActive(true);
                arrow.transform.Rotate(0, 0, 180);
                break;
            case 1:
                hitbox[1].gameObject.SetActive(true);
                //arrow.transform.Rotate(0, 0, 0);
                break;
            case 2:
                hitbox[2].gameObject.SetActive(true);
                arrow.transform.Rotate(0, 0, -90);
                break;
        }
    }
}