using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Cam : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject[] track;
    public GameObject target;
    public float movespeed;
    int i = 0;

    void Start()
    {
         
    }

    void Update()
    {
        //Vector3 Position = mainCamera.transform.position;
        //transform.LookAt(target.transform);
        //float Horizontal = Input.GetAxis("Horizontal");
        //float Vertical = Input.GetAxis("Vertical") ;
        //Position.x = Horizontal * Time.deltaTime * movespeed;
        //Position.z = Vertical * Time.deltaTime * movespeed;  

        //if(Input.GetKeyDown(KeyCode.Alpha8))
        //{
        //    Position.y = Position.y * Time.deltaTime * movespeed;
        //}
        //else if(Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    Position.y = Position.y * Time.deltaTime * -movespeed;
        //}
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Vector3 a = new Vector3(0, transform.position.y * Time.deltaTime * movespeed, 0);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Vector3 b = new Vector3(0, transform.position.y * Time.deltaTime * -movespeed, 0);
        }       
        transform.Translate(track[i].transform.position * Time.deltaTime * movespeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "track")
        {
            i++;
        }
    }
}
