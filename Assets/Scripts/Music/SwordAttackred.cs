using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackred : MonoBehaviour
{
    public GameObject test;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "RedEnemy")
        {
            ScoreManager.Instance.Hit();
            Destroy(col.gameObject);
            AttackPlayer.a = true;
        }
    }
}
