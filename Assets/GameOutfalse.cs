using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOutfalse : MonoBehaviour
{
    public GameObject FadeGameOut;
    public GameObject FadeGameIn;
    // Start is called before the first frame update
    void Start()
    {
        FadeGameOut.SetActive(false);
        FadeGameIn.SetActive(true);
    }
}
