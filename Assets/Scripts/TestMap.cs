using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMap : MonoBehaviour
{
    public GameObject map_Part1;
    public float map_flow;
    public Transform map_Spawn;
    bool isspawnd = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        MapFlow();
    }

    void MapFlow()
    {
        map_Part1.transform.Translate(new Vector3(map_flow, 0, 0));
        if (map_Part1.transform.position.z <= -31f)
        {
            isspawnd = false;
            if (isspawnd == false)
            {
                isspawnd = true;
                Instantiate(map_Part1, map_Spawn);
                Destroy(map_Part1, 3f);  
            }
    
            
        }
    }
}
