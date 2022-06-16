using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy_closs" || col.tag == "Enemy_far" || col.tag == "Note")
        {
            Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!³Ê Á×À½!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Destroy(col.gameObject);
            AttackPlayer.a = true;
        }
    }
}
