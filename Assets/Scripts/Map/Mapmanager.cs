using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapmanager : MonoBehaviour
{
    public GameObject map_Part1;
    public float map_flow;
    public Transform map_Spawn;
    public bool isspawnd = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        MapFlow();
    }

    void MapFlow()
    {
        switch (isspawnd)
        {

            case false:
                break;
            case true:          
                    Instantiate(map_Part1, gameObject.transform);
                isspawnd = false;
                break;
        }
    }
}
