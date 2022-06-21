using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2.0f);
    public void Start()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        for (int i = 0; i < 3; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void Update()
    {
        if(Lim_GameManager.Instance.IsPause == true)
        {
            setactive();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(transform.GetChild(0).tag == "Blue_Sword")
        {
            Lim_GameManager.Instance.IsPause = false;
            Debug.Log("111");
        }
        else if(other.tag == "Blue_Sword")
        {
            SceneManager.LoadScene("MainScene");
            Debug.Log("222");
        }

    }

    IEnumerator setactive()
    {
        yield return waitForSeconds;
        for (int i = 0; i < 3; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

}
