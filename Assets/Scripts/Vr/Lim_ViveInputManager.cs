using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;   //���� VR ���ӽ����̽�

public class Lim_ViveInputManager : MonoBehaviour
{
    public SteamVR_Action_Boolean menu;



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

       
    }
}
