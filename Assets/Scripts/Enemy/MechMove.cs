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
    public GameObject arrow;
    string[] hitType = {"RedEnemy", "BlueEnemy"};
    public static bool pigock = false;

    //근접용
    Transform player;
    float ableDistance = 7;

    //원거리용
    public enum pos { left, right };
    pos p;

    void Start()
    {
        player = MusicManager.Instance.Player.transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.LookAt(player.transform);
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
        gameObject.tag = hitType[Random.Range(0, 2)];   //적,청
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

        switch (state)      //판정 형태 결정
        {
            case State.Melee:
                switch (gameObject.tag)
                {
                    case "RedEnemy":
                        arrow.name = "Red";
                        break;
                    case "BlueEnemy":
                        arrow.name = "Blue";
                        break;
                }
                break;
            case State.Shoot:
                arrow.name = "AimPoint";
                break;
        }
    }

    void Attack()       //근접공격
    {
        animator.SetFloat("Speed", 2);   
        //float distance = Vector3.SqrMagnitude(transform.position - player.position);
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= ableDistance)
        {
            animator.SetInteger("MeleeType", Random.Range(0, 2));
            animator.SetTrigger("MeleeAttack");
        }
    }

    void Shoot(pos p)       //원거리
    {
        animator.SetFloat("Speed", 1);
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= ableDistance+6)
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
