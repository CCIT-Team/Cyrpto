using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackred : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (HItBox.inHit == true)
        {
            if (col.tag == "RedEnemy")
            {
                ScoreManager.Instance.Hit();
                MechMove.pigock = true;
                //Destroy(col.gameObject);
            }
        }
    }
}
