using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;   //���� VR ���ӽ����̽�

public class Lim_ViveInputLeftHandManager: MonoBehaviour
{
    public SteamVR_Action_Boolean ltrigger;
    public SteamVR_Action_Vibration haptic;

    public Transform shootpos;
    public GameObject projectile;

    void Start()
    {
        
    }

    void Update()
    {
        if (ltrigger.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Debug.Log("Ʈ���� ����");
            Vector3 forward = transform.TransformDirection(0,0,1) * 10;
            Debug.DrawRay(transform.position, forward, Color.green);
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
