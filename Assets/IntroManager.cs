using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    GameObject Title;
    [SerializeField]
    GameObject Mainmenu;
    [SerializeField]
    GameObject Setting;
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2.0f);

    void Start()
    {
        
    }

    void Update()
    {
    
    }
    IEnumerator active1()
    {
        yield return waitForSeconds;
        transform.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = false;
        transform.GetChild(1).gameObject.GetComponent<BoxCollider>().enabled = false;
        transform.GetChild(2).gameObject.GetComponent<BoxCollider>().enabled = false;
        transform.GetChild(3).gameObject.GetComponent<BoxCollider>().enabled = false;
        
    }
}
