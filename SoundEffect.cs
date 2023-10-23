using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    
    [SerializeField] private AudioClip healthUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioController.Instance.PlaySound(healthUp);
            Destroy(gameObject);
        }
    }
}
