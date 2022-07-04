using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameGo : MonoBehaviour
{
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(0.5f);
    private void Start()
    {
        StartCoroutine(active());
    }
    IEnumerator active()
    {
        yield return waitForSeconds;
        SceneManager.LoadScene("MainScene");

    }
}
