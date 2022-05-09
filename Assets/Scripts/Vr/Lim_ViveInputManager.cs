using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;   //���� VR ���ӽ����̽�

public class Lim_ViveInputManager : MonoBehaviour
{
    public SteamVR_Action_Boolean menu;
    public SteamVR_Action_Boolean trigger;

    public SteamVR_Action_Vibration haptic;

    void Start()
    {
        
    }

    
    void Update()
    {
        //�޴� ��ư�� �������� 1ȸ
        if(menu.GetStateDown(SteamVR_Input_Sources.Any)) //��� ��Ʈ�ѷ� L,R �Ѵ�
        {
            Debug.Log("�޴� ����");
        }

        if (trigger.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Debug.Log("Ʈ���� ����");
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(transform.position, forward, Color.green);

            //���� ��ƽ�� ����� �������� ������
            //haptic.Execute(0, 0.3f, 10f, 1f, SteamVR_Input_Sources.LeftHand);
        }
        //haptic.Execute(0, 0f, 0f, 0f, SteamVR_Input_Sources.LeftHand);
        if(trigger.GetState(SteamVR_Input_Sources.RightHand))
        {
            Debug.Log("R Ʈ���� ����");
        }
    }
}
