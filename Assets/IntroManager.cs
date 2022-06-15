using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    GameObject Title;
    GameObject Mainmenu;
    GameObject Setting;

    void Start()
    {
        Title.SetActive(true);
    }

    void Update()
    {
        
    }
}
