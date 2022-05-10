using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public AttackType attack;
    Animator animator;
    public GameObject player;
    float distance;
    public float ableDistance = 0.0001f; //근접모션을 취하기 시작하는 거리

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
        transform.localPosition = Vector3.Lerp(Vector3.forward * MusicManager.Instance.NoteSpawnY, Vector3.forward * MusicManager.Instance.NoteDespawnY * player.transform.position.z, GetComponent<Note>().t);
        //distance = Vector3.Magnitude(transform.position - player.transform.position);
        //if (distance < ableDistance)
        //    animator.SetTrigger("MeleeAttack");
    }
}

public enum AttackType
{
    Close,
    Far,
};
