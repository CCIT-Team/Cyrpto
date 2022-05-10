using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMove : MonoBehaviour
{
    public enum State { Melee, Shoot }
    public State state;
    public int line;
    Animator animator;

    //±Ÿ¡¢
    Rigidbody rid;
    public float speed = 0.01f;
    public float jumpDelay = 1;
    public float jumpHeght = 1;
    public float jumpLenght = 1;
    
    public float ableDistance;

    AnimatorStateInfo currentstate;

    void Start()
    {
        animator = GetComponent<Animator>();
        rid = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        line = Random.Range(1, 8);
        if (line <= 2|| line >= 7)
        {
            state = State.Shoot;
        }
        else
        {
            state = State.Melee;
        }
    }
    
    void Update()
    {
        if (currentstate.IsName("Walk"))
        {
            transform.Translate(Vector3.forward * speed);
        }

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

    void Attack()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Magnitude(transform.position - player.transform.position);
        if (distance < ableDistance)
            animator.SetTrigger("MeleeAttack");

        currentstate = animator.GetCurrentAnimatorStateInfo(0);
        if (currentstate.IsName("JumpAttack"))
        {
            StartCoroutine("JumpMove");
        }
    }

    void Shoot()
    {
        animator.SetInteger("AttackType",Random.Range(0,3));
        animator.SetBool("Attack",true);
    }

    IEnumerator JumpMove()
    {
        yield return new WaitForSecondsRealtime(jumpDelay * 0.4f);
        //animator.transform.Translate(0, jumpHeght*0.05f, jumpLenght*0.05f);
        rid.AddForce(new Vector3(0, jumpHeght, jumpLenght), ForceMode.Impulse);
    }
}
