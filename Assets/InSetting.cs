using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSetting : MonoBehaviour
{
    //public GameObject sync, reset, exit;


    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2.0f);
    private void OnEnable()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        for (int i = 0; i < 6; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<BoxCollider>().enabled = false;
        }

    }
    public void Update()
    {
        if (Lim_GameManager.Instance.IsSetting == true)
        {
            setactive();
        }
    }

    IEnumerator setactive()
    {
        yield return waitForSeconds;
        for (int i = 0; i < 6; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

}
