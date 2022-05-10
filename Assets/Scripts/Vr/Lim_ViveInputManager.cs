using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;   //스팀 VR 네임스페이스

public class Lim_ViveInputManager : MonoBehaviour
{
    public SteamVR_Action_Boolean menu;



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

       
    }
}
