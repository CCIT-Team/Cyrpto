using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackred : MonoBehaviour
{
    public static bool isredcut = false;
    void OnTriggerEnter(Collider col)
    {
        if (HItBox.inHit == true && col.CompareTag("RedEnemy"))
        {
            MechMove.pigock = true;
            if (MechMove.pigock == true)
            {
                isredcut = true;
                ScoreManager.Instance.Hit();
                //Destroy(col.gameObject);
                Debug.Log(isredcut);
            }
        }
    }
}

