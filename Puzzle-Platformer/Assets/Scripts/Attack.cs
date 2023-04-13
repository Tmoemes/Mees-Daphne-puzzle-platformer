using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator playerAnimator;
    public AudioClip[] SoundEffects;
    private AudioSource _audioSource;
    public float attackTime = 0.1f;
    public float attackCooldown = 0.6f;
    public float attackDamage = 25.0f;
    private bool canAttack = true;
    private bool hitSomething = false;
    private Collider hitbox;

    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<Collider>();
        hitbox.enabled = false;
        _audioSource = GetComponent<AudioSource>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
        Debug.Log(other.name);
        hitSomething = true;
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            _audioSource.PlayOneShot(SoundEffects[2]);
            enemy.TakeDamage(attackDamage);
        }
        else
        {
            _audioSource.PlayOneShot(SoundEffects[1]);
        }
        
            
    }

    IEnumerator StartAttackTime()
    {
        yield return new WaitForSeconds(attackTime);
        hitbox.enabled = false;
        if (!hitSomething)
        {
            _audioSource.PlayOneShot(SoundEffects[0]);
        }
        hitSomething = false;
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
