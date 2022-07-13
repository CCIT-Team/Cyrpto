using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackblue:MonoBehaviour
{
    public static bool isbluecut = false;
    void OnTriggerEnter(Collider col)
    {
        if (HItBox.inHit == true && col.CompareTag("BlueEnemy"))
        {
            MechMove.pigock = true;
            if (MechMove.pigock == true)
            {
                isbluecut = true;
                ScoreManager.Instance.Hit();
                //Destroy(col.gameObject);
                Debug.Log(isbluecut);
            }
        }
    }
}
