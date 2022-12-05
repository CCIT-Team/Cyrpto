using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lim_title : MonoBehaviour
{
    public GameObject disable;
    public bool uiactive;
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2.0f);

    private void OnEnable()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        for(int i = 0; i < 4; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void Update()
    {
        StartCoroutine(active());
        //Destroy(titlePrefab, 3f);
    }
    public void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Blue_Sword")
        {
            disable.SetActive(false);
        }

    }
    IEnumerator active()
    {
        yield return waitForSeconds;
        gameObject.GetComponent<BoxCollider>().enabled = true;
        for (int i = 0; i < 4; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        uiactive = true;
    }

}
