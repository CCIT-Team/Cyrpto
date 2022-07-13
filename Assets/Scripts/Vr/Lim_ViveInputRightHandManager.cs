using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Lim_ViveInputRightHandManager : MonoBehaviour
{
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2.5f);
    public SteamVR_Action_Boolean rtrigger;
    public SteamVR_Action_Boolean menu;
    public SteamVR_Action_Vibration haptic;
    public GameObject SwordObject;
    public GameObject Redsword;
    public GameObject Bluesword;
    public GameObject Rpause;
    public bool rtriggeron;
    public GameObject mon;
    public HItBox hItBox;
    public AudioClip close;
    public AudioSource closeSource;

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
        closeSource.GetComponent<AudioSource>();
        StartCoroutine(closemon());
    }

    // Update is called once per frame
    public void Update()
    {
        if(menu.GetState(SteamVR_Input_Sources.RightHand))
        {

            //Rpause.SetActive(true);
            Lim_GameManager.Instance.IsPause = true;
        }
        if (rtrigger.GetState(SteamVR_Input_Sources.RightHand))
        {
            //Debug.Log("R 트리거 눌림");
            rtriggeron = true;
            Redsword.SetActive(false);
            Bluesword.SetActive(true);
        }
        else
        {
            rtriggeron = false;
            Redsword.SetActive(true);
            Bluesword.SetActive(false);
        }

        if(hItBox.closemondead == true)
        {
            closeSource.PlayOneShot(close);
        }
    }

    IEnumerator closemon()
    {
        yield return waitForSeconds;
        mon = GameObject.Find("NPC_Mech_LOD1_LWRP");
        hItBox = mon.GetComponent<HItBox>();
    }
}
    

