using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.Linq;

public class AGB_Sword : MonoBehaviour
{
  

    public GameObject SwordObject;
    GameObject Asword;
    GameObject Bsword;

  
   
    private void Start()
    {
        Asword = SwordObject.transform.GetChild(0).gameObject;
        Bsword = SwordObject.transform.GetChild(1).gameObject;
        Asword.SetActive(true);
        Bsword.SetActive(false);
   

    }

    public void SelectSword(bool triger)
    {
        if (triger)
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
