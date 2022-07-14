using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class great : MonoBehaviour
{
    static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);
    bool isgreat = false;

    public GameObject asd;

    private void Awake()
    {
        isgreat = false;

        asd.GetComponent<BoxCollider>();
        
    }
    private void OnTriggerStay(Collider other)
    {
        isgreat = true;
        if(other.tag == "panj")
        {
            StartCoroutine(waitGreat());
        }
    }

    private void Update()
    {
        
    }

    IEnumerator waitGreat()
    {
        yield return waitForSeconds;
        ScoreManager.instance.Great();

    }


}
