using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lim_Bullet : MonoBehaviour
{
    public float bulletspeed = 100f;

    private Transform tr;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * bulletspeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
