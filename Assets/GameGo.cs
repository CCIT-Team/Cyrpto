using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameGo : MonoBehaviour
{
    public Title title;
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
    public GameObject Fade;

    public void Start()
    {
        Fade.SetActive(true);
    }
    private void Update()
    {
        if(title.Next == true)
        {
            StartCoroutine(active());
        }
    }
    IEnumerator active()
    {
        yield return waitForSeconds;
        SceneManager.LoadScene("MainScene");

    }
}
