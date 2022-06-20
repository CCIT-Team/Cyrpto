using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;   //스팀 VR 네임스페이스
public class Lim_ViveInputLeftHandManager: MonoBehaviour
{
    public SteamVR_Action_Boolean ltrigger;
    public SteamVR_Action_Boolean menu;
    public SteamVR_Action_Vibration haptic;

    public Transform shootpos;
    public GameObject projectile;
    public GameObject Lpause;
    //public bool Ispause;


    void Start()
    {

    }

    public void Update()
    {
        if (menu.GetState(SteamVR_Input_Sources.LeftHand))
        {
            
            //Lpause.SetActive(false);
            Lim_GameManager.Instance.IsPause = false;
        }

        if (ltrigger.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            //Debug.Log("트리거 눌림");
            Vector3 forward = transform.TransformDirection(0,0,1) * 10;
            Shoot();
            //현재 햅틱은 기계적 결함으로 제외함
            //haptic.Execute(0, 0.3f, 10f, 1f, SteamVR_Input_Sources.LeftHand);
        }
        //haptic.Execute(0, 0f, 0f, 0f, SteamVR_Input_Sources.LeftHand);
    }

    public void Shoot()
    {
        Instantiate(projectile, shootpos.position, shootpos.rotation);
        

    }

}
