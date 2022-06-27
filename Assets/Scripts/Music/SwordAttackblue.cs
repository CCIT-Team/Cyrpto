using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackblue:MonoBehaviour
{
    public static int Combo = 0;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "BlueEnemy")
        {
            //Destroy(col.gameObject);
            AttackPlayer.a = true;
            ScoreManager.Instance.Hit();
        }
    }
}
