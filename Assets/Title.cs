using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public GameObject titlePrefab;
    public GameObject disable;
    public bool Next;
    public bool uiactive;
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2.0f);


    private void Update()
    {
        StartCoroutine(active());
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Blue_Sword")
        {
            Instantiate(titlePrefab);
            Next = true;
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

