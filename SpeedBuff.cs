using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : MonoBehaviour
{
    public float multiplier = 10f;
    public float duration = 3f;
    [SerializeField] private AudioClip poderVelocidad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioController.Instance.PlaySound(poderVelocidad);
            StartCoroutine(Hermes(collision));
        }
    }



    IEnumerator Hermes(Collider2D player)
    {
        PlayerController Flash = player.GetComponent<PlayerController>();
        Flash.velocidadMovimiento *= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);
        Flash.velocidadMovimiento /= multiplier;

        Destroy(gameObject);
    }
}
