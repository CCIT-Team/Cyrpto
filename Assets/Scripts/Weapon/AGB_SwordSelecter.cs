using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGB_SwordSelecter : MonoBehaviour
{
    GameObject SwordObject;
    GameObject Asword;
    GameObject Bsword;


    private void Awake()
    {
        SwordObject = this.transform.gameObject;
    }
    private void Start()
    {
        Asword = SwordObject.transform.GetChild(0).gameObject;
        Bsword = SwordObject.transform.GetChild(1).gameObject;
        Asword.SetActive(true);
        Bsword.SetActive(false);
       

    }

    public void SelectSword(bool triger)
    {
        if (!triger)
        {
     
            Asword.SetActive(true);
            Bsword.SetActive(false);
        }
        else
        {
            Asword.SetActive(false);
            Bsword.SetActive(true);
        }

    }
}
