using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSetting : MonoBehaviour
{
    public AudioClip settingsound;
    public AudioSource audioSource;

    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2.0f);
    private void OnEnable()
    {
        audioSource.PlayOneShot(settingsound);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        for (int i = 0; i < 6; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<BoxCollider>().enabled = false;
        }

    }
    public void Update()
    {
        if (Lim_GameManager.instance.IsSetting == true)
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
