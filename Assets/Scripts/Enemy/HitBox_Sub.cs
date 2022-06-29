using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox_Sub : MonoBehaviour
{
    public HItBox Hit;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Blue_Sword" || other.tag == "Red_Sword")
        {
            HItBox.inHit = true;
        }
    }
}
