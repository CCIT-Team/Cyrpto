using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainbreak1 : MonoBehaviour
{
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2.0f);
    private void Awake()
    {
        ScoreManager.instance.combocount = 0;
        ScoreManager.instance.finalScore = 0;
        ScoreManager.instance.finalScorehave = 0;
        ScoreManager.instance.finalSocorefloat = 0;
        ScoreManager.instance.finalsocreup = 0;
        ScoreManager.instance.goodCount = 0;
        ScoreManager.instance.greatCount = 0;
        ScoreManager.instance.peroectCount = 0;
        ScoreManager.instance.missCount = 0;
        ScoreManager.instance.score[0] = 0;
        ScoreManager.instance.score[1] = 0;
        ScoreManager.instance.score[2] = 0;
        ScoreManager.instance.gameend = false;

        StartCoroutine(test());
    }

    IEnumerator test()
    {
        yield return waitForSeconds;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
