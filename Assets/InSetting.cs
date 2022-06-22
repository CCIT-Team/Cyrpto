using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSetting : MonoBehaviour
{
    public GameObject setting;


    private void OnTriggerEnter(Collider set)
    {
        if(set.tag == "Bule_Sword")
        {
            Lim_GameManager.Instance.IsPause = false;
            setting.SetActive(true);
            Time.timeScale = 0.1f;
        }
        
    }
}
