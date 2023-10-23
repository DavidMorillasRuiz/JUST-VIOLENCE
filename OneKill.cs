using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneKill : MonoBehaviour
{
    public int multiplier = 10;
    public float duration = 3f;
    [SerializeField] private AudioClip poderAumnetado;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioController.Instance.PlaySound(poderAumnetado);
            StartCoroutine(Punch());
        }
    }



    IEnumerator Punch()
    {
        
        GameManager.Instance.attackDamage *= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);
        GameManager.Instance.attackDamage /= multiplier;

        Destroy(gameObject);
    }
}
