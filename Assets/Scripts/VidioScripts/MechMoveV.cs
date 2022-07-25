using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMoveV : MonoBehaviour
{
    Animator animator;
    public GameObject arrow;
    string[] hitType = {"RedEnemy", "BlueEnemy"};
    public static bool pigock = false;

    //근접용
    Transform player;
    float ableDistance = 7;

    void Start()
    {
        player = MusicManager.Instance.Player.transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
        if (animator.GetBool("MeleeAttack"))
            animator.speed = 0.1f;
        else
            animator.speed = 1;
    }

    private void OnEnable()
    {
        gameObject.tag = hitType[Random.Range(0, 2)];   //적,청
    }

    void Attack()       //근접공격
    {
        animator.SetFloat("Speed", 2);   
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= ableDistance)
        {
            animator.SetTrigger("MeleeAttack");
        }
    }
}
