using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackblue:MonoBehaviour
{  
    void OnTriggerEnter(Collider col)
    {
        if (HItBox.inHit == true)
        {
            if (col.tag == "BlueEnemy")
            { 
                ScoreManager.Instance.Hit();
                MechMove.pigock = true;
               // Destroy(col.gameObject);
            }
        }
    }
}
