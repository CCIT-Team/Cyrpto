using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackblue:MonoBehaviour
{
    public AudioClip close;
    public AudioSource closeSource;
    public static bool isbluecut = false;

    private void Start()
    {
        closeSource = GetComponent<AudioSource>();
    }
void OnTriggerEnter(Collider col)
    {
        /*
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
        }*/
        if (col.GetComponent<HitBox>().isbreak)
        {
            Debug.Log("----------------------------------------------------------------------»ç¿îµå---------------------------------------------------------------------------");
            closeSource.PlayOneShot(close);
        }
        
    }
    
}
