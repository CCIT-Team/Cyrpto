using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Lim_GameManager.Instance.maxHp = 100;
        Lim_GameManager.Instance.hp = 50;
        Lim_GameManager.Instance.offsettest = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
