using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour , IGetHit
{
    public float health = 100f;
    public float attackDamage = 10f;
    public float attackRange = 1f;
    public float attackSpeed = 1f;
    public float moveSpeed = 1f;

    private float attackCooldown = 0f;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent =  GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player");
        navMeshAgent.destination = Player.transform.position;
        navMeshAgent.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = Player.transform.position;
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            health = 0f;
            animator.Play("Die");
            navMeshAgent.isStopped = true;
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            animator.Play("Hit");
        }
        Debug.Log("Taking Damage, current health=" + health);
    }
}
