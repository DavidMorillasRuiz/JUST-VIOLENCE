using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeDamge : MonoBehaviour
{
    private PlayerCombat playerCombat;
    private Animator anim;


    private void Start()
    {
        playerCombat = GetComponent<PlayerCombat>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Attack();
            other.gameObject.GetComponent<PlayerCombat>().TakeDamage(1, other.GetContact(0).normal);
            GameManager.Instance.PerderVida();
        }
    }
    public void Attack()
    {
        anim.SetTrigger("attack");


    }
}
