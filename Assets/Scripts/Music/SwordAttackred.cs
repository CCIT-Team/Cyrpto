using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackred : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "RedEnemy")
        {
            if(HItBox.inHit == true )
            {
                ScoreManager.Instance.Hit();
                Destroy(col.gameObject);
                MechMove.pigock = true;
            }          
        }
     }

}
