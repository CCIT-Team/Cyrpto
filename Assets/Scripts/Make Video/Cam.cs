using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject target;
    public float movespeed;
    int i = 0;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            transform.LookAt(target.transform);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
           transform.position +=  Vector3.up * movespeed;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            transform.position += Vector3.up;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.down * movespeed;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.position += Vector3.down;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * movespeed;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            transform.position += Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * movespeed;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            transform.position += Vector3.back;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * movespeed;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            transform.position += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * movespeed;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            transform.position += Vector3.right;
        }
    }
}

