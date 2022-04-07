using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaderproperti : MonoBehaviour
{
    public Material mtr;
    public string propcertyname;
    public float maxValue = -1;

    public float timespeed = 0.05f;

    public void Start()
    {
        //mtr.SetFloat(propcertyname, maxValue);
    }

    // Update is called once per frame
    void Update()
    {

        mtr.SetFloat(propcertyname, maxValue);
        maxValue += timespeed;
    }
}
