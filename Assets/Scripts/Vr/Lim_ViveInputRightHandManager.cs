using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Lim_ViveInputRightHandManager : MonoBehaviour
{
    public SteamVR_Action_Boolean rtrigger;
    public SteamVR_Action_Vibration haptic;
    public GameObject SwordObject;
    public GameObject Redsword;
    public GameObject Bluesword;

    private void Awake()
    {
        SwordObject = this.transform.gameObject;
    }

    void Start()
    {
        Redsword = SwordObject.transform.GetChild(0).gameObject;
        Bluesword = SwordObject.transform.GetChild(1).gameObject;
        Redsword.SetActive(true);
        Bluesword.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (rtrigger.GetState(SteamVR_Input_Sources.RightHand))
        {
            Debug.Log("R 트리거 눌림");

            Redsword.SetActive(false);
            Bluesword.SetActive(true);
        }
        else
        {
            Redsword.SetActive(true);
            Bluesword.SetActive(false);
        }
    }
}
    

