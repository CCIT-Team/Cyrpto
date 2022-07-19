using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class shootonly : MonoBehaviour
{
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(1.5f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blue_Sword")
        {
            SceneManager.LoadScene("shoot only");
        }
    }

    IEnumerator active()
    {
        yield return waitForSeconds;
        SceneManager.LoadScene("musictest");

    }
}
