using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lim_Blade : MonoBehaviour
{
    BoxCollider boxcollider;
    Rigidbody rb;
    public bool isCutting;
    public float mincut = 0.05f;
    Vector3 perpos;
    // Update is called once per frame

    private void Start()
    {
        boxcollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        updatecutting();
    }

    void Startcutting()
    {
        isCutting = true;
    }

    void updatecutting()
    {
        Vector3 newpos = gameObject.transform.position.normalized;
        Vector3 wolrdpos = transform.localPosition.normalized;
        float velocity = (newpos - wolrdpos).sqrMagnitude * Time.deltaTime;
        Debug.Log(velocity);
        if(velocity > mincut)
        {
            boxcollider.enabled = true;
        }
        else
        {
            boxcollider.enabled = false;
        }

    }
}
