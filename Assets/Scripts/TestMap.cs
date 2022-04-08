using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMap : MonoBehaviour
{
    public GameObject map_Part1;
    public Collider map_End;
    public float map_flow;
    public float map_SpawnPoint;
    public Transform Spawn_Point;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(new Vector3(map_flow, 0, 0));
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            map_End = col; //= map_End.GetComponent<BoxCollider>();
            Debug.Log("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz");
            Instantiate(map_Part1, Spawn_Point.position, new Quaternion(0, 0, 0, 0)); 
        }
        
    }
}
