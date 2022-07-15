using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class resultnext : MonoBehaviour
{
    public ResultWindow resultWindow;
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(3f);
    public static readonly WaitForSeconds waitForSeconds1 = new WaitForSeconds(0.01f);
    public GameObject reslut;
    public Image image;


    public void Start()
    {

    }

    private void Update()
    {
        if (resultWindow.isresult == true)
        {
            //StartCoroutine(fadenextstep());
            StartCoroutine(active());
            StartCoroutine(fadenextstep());
            reslut.SetActive(false);
            //image.color = new Color(0, 0, 0, 0);

        }
    }
    IEnumerator active()
    {
        yield return waitForSeconds;
        SceneManager.LoadScene("MainScene");
        resultWindow.isresult = false;
    }
    IEnumerator fadenextstep()
    {
        float fadecount = 1;
        while (fadecount < 0.0f)
        {
            fadecount -= 0.01f;
            yield return waitForSeconds1;
            image.color = new Color(0, 0, 0, fadecount);
        }
    }
}
