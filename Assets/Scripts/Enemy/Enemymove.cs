using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]


public class Enemymove : MonoBehaviour
{
    Animator animator;
    Rigidbody rid;
    public float speed=0.5f;
    public float jumpDelay = 1;
    public float jumpHeght = 1;
    public float jumpLenght = 1;
    AnimatorStateInfo currentstate;

    void Start()
    {
        animator = GetComponent<Animator>();
        rid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentstate = animator.GetCurrentAnimatorStateInfo(0);
        if (currentstate.IsName("JumpAttack"))
        {
            StartCoroutine("JumpMove");
        }

        if (currentstate.IsName("Walk"))
        {
            transform.Translate(Vector3.forward * speed);
        }
    }

    IEnumerator JumpMove()
    {
        yield return new WaitForSecondsRealtime(jumpDelay*0.4f);
        //animator.transform.Translate(0, jumpHeght*0.05f, jumpLenght*0.05f);
        rid.AddForce(new Vector3(0, jumpHeght, jumpLenght), ForceMode.Impulse);
    }
}
