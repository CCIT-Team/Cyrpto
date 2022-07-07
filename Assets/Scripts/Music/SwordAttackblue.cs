using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackblue:MonoBehaviour
{  
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "BlueEnemy")
        {
            ScoreManager.Instance.Hit();
            Destroy(col.gameObject);
            MechMove.pigock = true;
        }
    }
}
