using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackred : MonoBehaviour
{
    public AudioClip close;
    public AudioSource closeSource;
    public static bool isredcut = false;

    private void Start()
    {
        closeSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider col)
    {
        /*
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
        }*/
        if(col.GetComponent<HItBox>().isHit)
        {
            closeSource.PlayOneShot(close);
        }
    }
}

