using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public AttackType attack;
    Animator animator;
     GameObject player;
    float distance;
    public float ableDistance = 0.0001f; //근접모션을 취하기 시작하는 거리
    public float Speed;
    public float d;
    public static bool a = false;
    private void Awake()
    {
        player = MusicManager.Instance.Player;
    }
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetFloat("Speed", 2f);  
    }


    void Update()
    {
        transform.localPosition = Vector3.Lerp(Vector3.forward * MusicManager.Instance.NoteSpawnZ, 
            Vector3.forward * MusicManager.Instance.NoteDespawnZ * (player.transform.position.z - 5), Note.t - Speed);

        //distance = Vector3.Magnitude(Lane.note.transform.position - player.transform.position);
        //Debug.Log(distance);
        //if (distance < ableDistance)
        //    animator.SetTrigger("MeleeAttack");
        if(distance < ableDistance) { animator.SetTrigger("MeleeAttack"); }
    }
}


public enum AttackType
{
    Close,
    Far,
};
