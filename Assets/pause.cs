using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{

    public AudioClip pausesound;
    public AudioSource audioSource;
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2.0f);
    private void OnEnable()
    {
        audioSource.PlayOneShot(pausesound);
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

    IEnumerator setactive()
    {
        yield return waitForSeconds;
        for (int i = 0; i < 3; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

}
