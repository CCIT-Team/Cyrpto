using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;   //스팀 VR 네임스페이스

public class Lim_ViveInputManager : MonoBehaviour
{
    #region
    public static Lim_ViveInputManager Instance 
    {
        get { return instance; }
        set { }
    }
    #endregion
    public static Lim_ViveInputManager instance = null;

    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        
        DontDestroyOnLoad(gameObject);
    }
}
