using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    Animator animator;
    public GameObject player;
    float distance;
    public float ableDistance = 0.0001f; //��������� ���ϱ� �����ϴ� �Ÿ�

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        animator.SetFloat("Speed", 2f);
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        distance = Vector3.Magnitude(transform.position - player.transform.position);
        if (distance < ableDistance)
            animator.SetTrigger("MeleeAttack");
    }
}

enum AttackType
{
    Close,
    Far,
};
