using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public static int Combo = 0;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy_closs" || col.tag == "Enemy_far")
        {
            Destroy(col.gameObject);
            AttackPlayer.a = true;
            Combo++;
        }
    }
}
