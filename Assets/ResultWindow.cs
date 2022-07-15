using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ResultWindow : MonoBehaviour
{
    public bool GameEnd;
    public GameObject titlePrefab;
    public GameObject setative;
    public bool isresult;


    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Blue_Sword")
        {
            //isresult = true;
            SceneManager.LoadScene("MainScene");
            Instantiate(titlePrefab);
            setative.SetActive(false);


        }
    }
}
