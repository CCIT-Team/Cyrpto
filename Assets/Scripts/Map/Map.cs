using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Mapmanager mmn;
    public static bool isEnd = false;

    void Start()
    {
        mmn = GameObject.FindGameObjectWithTag("MapManager").GetComponent<Mapmanager>(); ;
    }

    
    void Update()
    {
        MoveMap();
    }

    void MoveMap()
    {
        transform.Translate(new Vector3(mmn.map_flow, 0, 0));
        //if (transform.position.z <= -31f)
        //{
        //    mmn.isspawnd = true;
        //    Destroy(gameObject, 2f);
        //}
    }
}
