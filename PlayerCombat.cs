using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D playerRb;

  
    public event EventHandler MuerteJugador;
    [SerializeField] private float tiempoPerdidaControl;
    private PlayerController playerController;
   



    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        
        anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }




    public void TakeDamage(int amount,Vector2 posicion)
    {
        if (GameManager.Instance.playerHealth > 0)
        {
            anim.SetTrigger("Daño");
            StartCoroutine(PerderControl());
            StartCoroutine(DesactivarCollision());
            playerController.Rebote(posicion);

        }
        else
        {
            playerRb.constraints = RigidbodyConstraints2D.FreezeAll;
            anim.SetTrigger("Muerte");
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"), LayerMask.NameToLayer("Enemigos"), true);

        }
    }




    public void MuerteJugadorEvento()
    {
        MuerteJugador?.Invoke(this,EventArgs.Empty);
    }


    

    private IEnumerator DesactivarCollision()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(tiempoPerdidaControl);
        Physics2D.IgnoreLayerCollision(6, 7, false);

    }



    private IEnumerator PerderControl()
    {
        playerController.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        playerController.sePuedeMover = true;

    }


    
}
