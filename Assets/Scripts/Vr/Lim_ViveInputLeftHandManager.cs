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
    //public bool Ispause;


    void Start()
    {

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
        if(Physics.Raycast(shootpos.transform.position, shootpos.transform.forward, out hit, 1000))
        {
            if(hit.collider.tag == "Enemy_closs")
            {
                Debug.Log(hit.collider.name);
                Destroy(hit.collider.gameObject, 0.1f);
            }
            else if(hit.collider.name == "Resume")
            {
                Lim_GameManager.Instance.IsPause = false;
            }
            else if(hit.collider.name == "Reture")
            {
                Lim_GameManager.Instance.IsPause = false;
                if (Lim_GameManager.Instance.IsPause == false)
                {
                    Lim_GameManager.Instance.returnscene();
                }
               
            }
            else if(hit.collider.name == "Setting")
            {
                Lim_GameManager.Instance.SettingPopup();
            }

        }
        


    }

}
