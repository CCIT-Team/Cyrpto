using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechAnimation : MonoBehaviour
{
    //기본변수
    public enum State { Melee, Shoot }
    public int line;
    Animator animator;
    
    public State state;
    public static bool pigock = false;

    public bool meleeOnly = false;
    public bool shotOnly = false;

    //근접용
    Transform player;
    float ableDistance = 7;
    float distance;

    void Start()
    {
        player = MusicManager.Instance.Player.transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        // transform.LookAt(player.transform);
        if (meleeOnly)
            state = State.Melee;
        else if (shotOnly)
            state = State.Shoot;
        switch (state)
        {
            case State.Melee:
                Attack();
                break;
            case State.Shoot:
                Shoot();
                break;
        }
    }

    private void OnEnable()
    {
        if (meleeOnly)
            line = Random.Range(3, 6);
        else if (shotOnly)
            line = Random.Range(0, 3);
        else
            line = Random.Range(0, 6);

        if (line <= 2)
        {
            state = State.Shoot;
            gameObject.layer = 10; //원거리
        }
        else
        {
            state = State.Melee;
            gameObject.layer = Random.Range(8, 10);   //8 = 적, 9 = 청
        }
    }

    void Attack()       //근접공격
    {
        animator.SetFloat("Speed", 2);
        if (distance <= ableDistance)
        {
            animator.SetInteger("MeleeType", Random.Range(0, 2));
            animator.SetTrigger("MeleeAttack");
        }
    }

    void Shoot()       //원거리
    {
        animator.SetFloat("Speed", 1);
        if (distance <= ableDistance + 6 )
        {
            animator.SetTrigger("Shoot");
        }

        /*
        float side = 0;
        Vector3 mechPos;
        RaycastHit hit;

        animator.SetFloat("Speed", 1.5f);
        switch (p)
        {
            case pos.left:
                side = 1.5f;
                break;
            case pos.right:
                side = -1.5f;
                break;
        }

        mechPos = new Vector3(transform.position.x, side, transform.position.z);
        Debug.DrawRay(mechPos, Vector3.forward * 2, Color.red);
        Physics.Raycast(mechPos, Vector3.forward, out hit, 2);
        if (transform.position.z > hit.point.z - 1 && transform.position.z < hit.point.z - 0.5)
        {
            animator.SetBool("Crouch", true);
        } */
    }
}
