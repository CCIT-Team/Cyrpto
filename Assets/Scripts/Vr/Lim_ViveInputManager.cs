using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;   //스팀 VR 네임스페이스

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
        //메뉴 버튼을 눌렀을때 1회
        if(menu.GetStateDown(SteamVR_Input_Sources.Any)) //모든 컨트롤러 L,R 둘다
        {
            Debug.Log("메뉴 눌림");
        }

        if (trigger.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Debug.Log("트리거 눌림");
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(transform.position, forward, Color.green);

            //현재 햅틱은 기계적 결함으로 제외함
            //haptic.Execute(0, 0.3f, 10f, 1f, SteamVR_Input_Sources.LeftHand);
        }
        //haptic.Execute(0, 0f, 0f, 0f, SteamVR_Input_Sources.LeftHand);
        if(trigger.GetState(SteamVR_Input_Sources.RightHand))
        {
            Debug.Log("R 트리거 눌림");
        }
    }
}
