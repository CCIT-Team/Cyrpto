using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMoving : MonoBehaviour
{
    public float moveSpeed = 0.5f;

    int rot;
    
    
    // Update is called once per frame
    void Start()
    {
        rot = (int)transform.rotation.y / 4;
    }

    void Update()
    {
        switch (rot)
        {
            case 0:
                transform.Translate(new Vector3(0, 0, -moveSpeed * Time.deltaTime * 60));
                break;
            case 1:
                transform.Translate(new Vector3(-moveSpeed * Time.deltaTime * 60, 0, 0));
                break;
            case 2:
                transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime * 60));
                break;
            case 3:
                transform.Translate(new Vector3(moveSpeed * Time.deltaTime * 60, 0, 0));
                break;
        }
    }
}
