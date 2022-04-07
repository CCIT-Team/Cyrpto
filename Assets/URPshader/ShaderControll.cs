using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderControll : MonoBehaviour
{
    public Material test1;
    public bool dead;
    public Renderer rend;

    public Shader shader1;
    public Shader shader2;
    private void Awake()
    {
        test1 = GetComponent<MeshRenderer>().material;
        rend = GetComponent<Renderer>();
    }

    public void Start()
    {
        rend.material.shader = shader1;
        //rend = GetComponent<Renderer>();
    }
    public void Update()
    {
        if (dead == true)
            rend.material.shader = shader2;
        else
            rend.material.shader = shader1;
    }
}