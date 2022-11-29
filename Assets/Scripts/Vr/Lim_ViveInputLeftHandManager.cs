using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;   //스팀 VR 네임스페이스

public class Lim_ViveInputLeftHandManager: MonoBehaviour
{
    public SteamVR_Action_Boolean ltrigger;
    public SteamVR_Action_Boolean menu;
    public SteamVR_Action_Vibration haptic;

    public float maxDistance = 15.0f;
    RaycastHit hit;
    public Transform shootpos;
    public GameObject projectile;
    public GameObject Lpause;

    public ParticleSystem muzzleFlash;
    public AudioClip fireSound, farSound;
    public AudioSource audioSource, farSource;
    public static bool isgunhit = false;
    public int layerMask = 6;
    //public bool Ispause;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (menu.GetState(SteamVR_Input_Sources.LeftHand))
        {
            Lim_GameManager.Instance.IsPause = false;
        }

        if (ltrigger.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            //Debug.Log("트리거 눌림");
            Vector3 forward = transform.TransformDirection(0,0,1) * 10;
            Shoot();
        }

    }

    public void Shoot()
    {

        Instantiate(projectile, shootpos.position, shootpos.rotation);
        muzzleFlash.Play();
        audioSource.PlayOneShot(fireSound);
        if(Physics.Raycast(shootpos.transform.position, shootpos.transform.forward, out hit, 1000,~layerMask))
        {
            if(hit.collider.tag == "farEnemy")
            {
                isgunhit = true;
                //Debug.Log(hit.collider.name);
                if (hit.collider.GetComponent<MechMove>().state == MechMove.State.Shoot)
                    hit.collider.GetComponent<HitBox>().Monbreak();
                farSource.PlayOneShot(farSound);
               
            }
            else if(hit.collider.name == "Resume")
            {
                Lim_GameManager.Instance.IsPause = false;
            }
            else if(hit.collider.name == "Reture" || hit.collider.name == "MainSettingExit")
            {
                Lim_GameManager.Instance.IsPause = false;
                if (Lim_GameManager.Instance.IsPause == false)
                {
                    Lim_GameManager.Instance.returnscene();
                }
               
            }
            else if(hit.collider.name == "Setting")
            {
                Lim_GameManager.Instance.IsSetting = true;
            }

            if(hit.collider.name == "Sync")
            {
                Debug.Log("싱크 매니져 온");
            }
            else if(hit.collider.name == "Reset")
            {
                Debug.Log("셋팅 리셋함");
                Lim_GameManager.Instance.IsSetting = false;
            }
            else if(hit.collider.name == "Exit")
            {
                Lim_GameManager.Instance.IsSetting = false;
            }



        }
        


    }
}
