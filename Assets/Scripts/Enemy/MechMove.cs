using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMove : MonoBehaviour
{
    //기본변수
    public enum State { Melee, Shoot }
    public State state;
    public int line;
    Animator animator;

    //근접용
    public Transform player;
    public float ableDistance;

    //원거리용
    public enum pos { left, right };
    pos p;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        switch (state)
        {
            case State.Melee:
                Attack();
                break;
            case State.Shoot:
                Shoot(p);
                break;
        }
    }

    private void OnEnable()
    {
        line = Random.Range(1, 8);
        if (line <= 2)
        {
            state = State.Shoot;
            p = pos.left;
        }
        else if (line >= 7)
        {
            state = State.Shoot;
            p = pos.right;
        }
        else
        {
            state = State.Melee;
        }
    }

    void Attack()
    {
        animator.SetFloat("Speed", 2);
        float distance = Vector3.Magnitude(transform.position - player.position);
        if (distance < ableDistance)
        {
            animator.SetInteger("MeleeType", Random.Range(0, 1));
            animator.SetTrigger("MeleeAttack");
        }
    }

    void Shoot(pos p)
    {
        float side = 0;
        Vector3 mechPos;
        RaycastHit hit;

        animator.SetFloat("Speed", 1);
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
        }
    }
}
