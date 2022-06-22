using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HItBox : MonoBehaviour
{
    string typeMatch;
    public bool inHit = false;
    int hitDir = 0;

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
                transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 1:
                transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 2:
                transform.GetChild(4).gameObject.SetActive(true);
                break;
        }
    }
}