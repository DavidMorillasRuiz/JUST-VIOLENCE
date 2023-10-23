using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyFollows3 : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController player;
    [SerializeField] private float moveSpeed;
    private Vector3 directionToPlayer;
    private Vector3 localeScale;
    private Enemy enemyStatus;
   



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyStatus = GetComponent<Enemy>();
        player = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        moveSpeed = 0.7f;
        localeScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyStatus.isDead == false)
        {
            Vector3 direction = (directionToPlayer.normalized - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
            MoveEnemy();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }



    private void MoveEnemy()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * moveSpeed;

    }

    private void LateUpdate()
    {
        if(rb.velocity.x > 0 )
        {
            transform.localScale = new Vector3(localeScale.x, localeScale.y, localeScale.z);
        }
        else if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-localeScale.x, localeScale.y, localeScale.z);
        }
        

    }


   

}
