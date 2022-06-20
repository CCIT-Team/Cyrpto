using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;   //���� VR ���ӽ����̽�
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
            //Debug.Log("Ʈ���� ����");
            Vector3 forward = transform.TransformDirection(0,0,1) * 10;
            Shoot();
            //���� ��ƽ�� ����� �������� ������
            //haptic.Execute(0, 0.3f, 10f, 1f, SteamVR_Input_Sources.LeftHand);
        }
        //haptic.Execute(0, 0f, 0f, 0f, SteamVR_Input_Sources.LeftHand);
    }

    public void Shoot()
    {
        Instantiate(projectile, shootpos.position, shootpos.rotation);
        

    }

}
