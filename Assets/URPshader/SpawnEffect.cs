using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    [SerializeField]
    Renderer rend;
    [SerializeField]
    Material mtrOrigne;
    [SerializeField]
    Material mtrDissolve;
    [SerializeField]
    float fadeTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeOut()
    {
        rend.material = mtrOrigne;
    }

    public void FadeIn()
    {
        rend.material = mtrDissolve;
    }
}
