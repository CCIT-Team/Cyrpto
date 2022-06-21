using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    private BoxCollider boxCollider;
    private RectTransform rectTransform;
    public GameObject[] gameObjects;
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2.0f);
    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        boxCollider = gameObject.AddComponent<BoxCollider>();

        boxCollider.size = rectTransform.sizeDelta;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(gameObjects[0].tag == "Blue_Sword")
        {
            Lim_GameManager.Instance.IsPause = false;
            Debug.Log("111");
        }
        else if(gameObjects[1].tag == "bullet")
        {
            SceneManager.LoadScene("MainScene");
            Debug.Log("222");
        }
        else if(gameObjects[2].tag == "bullet")
        {
            gameObjects[3].SetActive(true);
            Debug.Log("333");
        }
    }

    IEnumerator setactive()
    {
        yield return waitForSeconds;
    }

}
