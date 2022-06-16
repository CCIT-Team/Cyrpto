using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public float currenttime = 3f;
    public float cooltime = 0f;
    Lim_ViveInputRightHandManager manager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.Ispause == true)
        {
            Time.timeScale = 0;
        }
        else if(manager.Ispause == false)
        {
            Time.timeScale = 1;
        }
    }
}
