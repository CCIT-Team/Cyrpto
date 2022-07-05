using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackblue:MonoBehaviour
{
    public GameObject test;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "BlueEnemy")
        {
            ScoreManager.Instance.Hit();
            Destroy(col.gameObject);
            AttackPlayer.a = true;
        }
    }
}
