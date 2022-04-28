using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMap : MonoBehaviour
{
    public GameObject map_Part1;
    public float map_flow;
    public Transform map_Spawn;
    void Start()
    {
        
    }

    
    void Update()
    {
        map_Part1.transform.Translate(new Vector3(map_flow, 0, 0));
        if(map_Part1.transform.position.z <= -31f)
        {
            Destroy(map_Part1);
            Instantiate(map_Part1, map_Spawn);
        }
    }
}
