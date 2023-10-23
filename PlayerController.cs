using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float velocidadMovimiento;
    [SerializeField] private Vector2 direccion;
    public Rigidbody2D rb2D;
    private Animator anim;
    private bool isFacingRight = true;
    public bool Hit = false;
    public float jumpForce;


    [Header("Sound Player")]
    [SerializeField] private AudioClip hitSonido;


    [Header("Player Damage")]
    public bool sePuedeMover = true;
    [SerializeField] private Vector2 velocidadRebote;

    private float horizontalInput;
    private float verticalInput;


    // Start is called before the first frame update
    void Start()
    {
       
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
   


    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
        Movement();
        Attack();
        Dañar();
    }

  

    void Movement()
    {

        // Codigo de movimiento
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        //Codigo de flip
        if (horizontalInput < 0)
        {
            anim.SetBool("Run", true);
            if (!isFacingRight)
            {
                Flip();
            }
        }

        if (horizontalInput > 0)
        {
            anim.SetBool("Run", true);
            if (isFacingRight)
            {
                Flip();
            }
        }

        if (horizontalInput == 0)
        {
            anim.SetBool("Run", false);
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown("space"))
        {
            anim.SetTrigger("Punch");
            AudioController.Instance.PlaySound(hitSonido);
        }
    }



    public void Rebote(Vector2 puntoGolpe)
    {
        rb2D.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, velocidadRebote.y);
    }




    void Flip()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        isFacingRight = !isFacingRight; // le cambio el valor del bool al valor contrario que tenga en ese momento
    }



    void Dañar()
    {
        if (Hit)
        {
            rb2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            Hit = false;
        }

    }

  
}
