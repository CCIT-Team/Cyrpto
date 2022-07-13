using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackred : MonoBehaviour
{
    public static bool isredcut = false;
    void OnTriggerEnter(Collider col)
    {

        if (HItBox.inHit == true)
        {
            if (col.CompareTag("RedEnemy"))
            {
                MechMove.pigock = true;
                if(HItBox.inHit == true && MechMove.pigock == true)
                {
                    isredcut = true;
                    ScoreManager.Instance.Hit();
                    //Destroy(col.gameObject);
                }
            }
        }
    }
}
