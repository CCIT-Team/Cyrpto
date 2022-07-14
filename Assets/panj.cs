using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panj : MonoBehaviour
{
    bool isperfact;
    bool isgreat;
    bool isgood;

    private void Awake()
    {
        isperfact = false;
        isgreat = false;
        isgood = false;
    }
    private void OnTriggerStay(Collider panj)
    {
        Debug.Log(panj.gameObject.name);
        if(panj.gameObject.name == "perfact")
        {
            isperfact = true;
            isgreat = false;
            isgood = false;
            if(isperfact == true)
               ScoreManager.instance.Perpect();
        }
        else if(panj.gameObject.name == "Great")
        {
            isperfact = false;
            isgreat = true;
            isgood = false;
            if (isgreat == true)
                ScoreManager.instance.Great();
        }
        else if(panj.gameObject.name == "Good")
        {
            isperfact = false;
            isgreat = false;
            isgood = true;
            if (isgood == true)
                ScoreManager.instance.Good();
        }
        else
        {
            isperfact = false;
            isgreat = false;
            isgood = false;
            ScoreManager.instance.Miss();
        }
    }
}
