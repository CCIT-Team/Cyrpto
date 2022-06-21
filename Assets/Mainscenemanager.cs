using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mainscenemanager : MonoBehaviour
{
    public GameObject[] title;
    public GameObject[] mainmanu;
    public GameObject[] setting;

    public GameObject[] breaking;

    public Image[] images_chage;

    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2.0f);

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        
    }
    void imageChanger()
    {

    }
    void startGame()
    {
        
        SceneManager.LoadScene("Game_Scene");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blue_Sword")
        {
            startGame();
        }
    }

    IEnumerator OnActive()
    {
        yield return waitForSeconds;

    }

}
