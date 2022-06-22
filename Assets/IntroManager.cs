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
        for (int i = 0; i < 4; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<BoxCollider>().enabled = false;
        }

    }
}
