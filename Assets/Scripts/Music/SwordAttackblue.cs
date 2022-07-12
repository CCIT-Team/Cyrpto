using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackblue:MonoBehaviour
{
    public static bool isbluecut = false;
    void OnTriggerEnter(Collider col)
    {
        if (HItBox.inHit == true)
        {
            if (col.tag == "BlueEnemy")
            {
                MechMove.pigock = true;
                if (HItBox.inHit == true && MechMove.pigock == true)
                {
                    isbluecut = true;
                    ScoreManager.Instance.Hit();
                    //Destroy(col.gameObject);
                }
            }
        }
    }
}
