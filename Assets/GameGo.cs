using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameGo : MonoBehaviour
{
    //메인 메뉴도 이 방식으로 할 예정
    public Title title;
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2f);
    public static readonly WaitForSeconds waitForSeconds1 = new WaitForSeconds(0.01f);
    public Image image;
    public GameObject titledis, introSound;
    public void Start()
    {

    }
    private void Update()
    {
        if(title.Next == true)
        {
            introSound.SetActive(true);
            Destroy(titledis, 0.1f);
            StartCoroutine(fadenextstep());
            StartCoroutine(active());
        }
    }
    IEnumerator active()
    {
        yield return waitForSeconds;
        SceneManager.LoadScene("MainScene");

    }
    IEnumerator fadenextstep()
    {
        float fadecount = 0;
        while (fadecount < 1.0f)
        {
            fadecount += 0.01f;
            yield return waitForSeconds1;
            image.color = new Color(0, 0, 0, fadecount);

        }
    }
}
