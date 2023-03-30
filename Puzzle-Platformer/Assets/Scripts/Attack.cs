using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator playerAnimator;
    public float attackTime = 0.1f;
    public float attackCooldown = 0.6f;
    public float attackDamaged = 1.0f;
    private bool canAttack = true;
    private Collider hitbox;

    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<Collider>();
        hitbox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            canAttack = false;
            playerAnimator.CrossFadeInFixedTime("Attack", 0.1f);
            hitbox.enabled = true;
            StartCoroutine(ResetAttackCooldown());
            StartCoroutine(StartAttackTime());
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "Enemy")
                {
                    other.gameObject.GetComponent<Animator>().CrossFadeInFixedTime("Hit",0.1f);
                }

    }

    IEnumerator StartAttackTime()
    {
        yield return new WaitForSeconds(attackTime);
        hitbox.enabled = false;
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
