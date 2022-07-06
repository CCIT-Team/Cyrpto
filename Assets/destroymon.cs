using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroymon : MonoBehaviour
{
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2.5f);
    public GameObject mon;
    public void Start()
    {
        mon.gameObject.GetComponent<GameObject>();
        StartCoroutine(destorymon());
    }

    public IEnumerator destorymon()
    {
        yield return waitForSeconds;
        Destroy(mon);
    }

}
