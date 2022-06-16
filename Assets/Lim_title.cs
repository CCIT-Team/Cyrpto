using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lim_title : MonoBehaviour
{
    public GameObject titlePrefab;
    public GameObject disable;
    public bool uiactive;
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2.0f);
    private void OnEnable()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        transform.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = false;
        transform.GetChild(1).gameObject.GetComponent<BoxCollider>().enabled = false;
        transform.GetChild(2).gameObject.GetComponent<BoxCollider>().enabled = false;
        transform.GetChild(3).gameObject.GetComponent<BoxCollider>().enabled = false;
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
            Instantiate(titlePrefab);
            disable.SetActive(false);
        }

    }
    IEnumerator active()
    {
        yield return waitForSeconds;
        gameObject.GetComponent<BoxCollider>().enabled = true;
        transform.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = true;
        transform.GetChild(1).gameObject.GetComponent<BoxCollider>().enabled = true;
        transform.GetChild(2).gameObject.GetComponent<BoxCollider>().enabled = true;
        transform.GetChild(3).gameObject.GetComponent<BoxCollider>().enabled = true;
        uiactive = true;
    }

}
