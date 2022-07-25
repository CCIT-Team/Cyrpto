using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HItBoxV : MonoBehaviour
{
    public GameObject BreakMon;
    public ParticleSystem[] Dead;
    public GameObject arrow;
    GameObject breakParts;
    internal bool colorMatch;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Red_Sword" || other.tag == "Blue_Sword")
            Monbreak();
    }

    public void Monbreak()
    {
        breakParts = Instantiate(BreakMon);
        breakParts.transform.position = this.gameObject.transform.position + new Vector3(0, 0.2f, 0);
        Destroy(gameObject);
    }
}