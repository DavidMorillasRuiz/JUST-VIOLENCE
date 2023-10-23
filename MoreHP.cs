using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreHP : MonoBehaviour
{

    public float multiplier = 1.4f;
    public float duration = 3f;
    [SerializeField] private AudioClip poderVida;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioController.Instance.PlaySound(poderVida);
            StartCoroutine(VidaAumenta());
        }
    }



     IEnumerator VidaAumenta()
    {
        
        GameManager.Instance.playerHealth *= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>(). enabled = false;

        yield return new WaitForSeconds(duration);
        GameManager.Instance.playerHealth /= multiplier;

        Destroy(gameObject);
    }

}
