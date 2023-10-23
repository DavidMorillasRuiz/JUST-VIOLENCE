using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource= GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip soundEffect)
    {
        audioSource.PlayOneShot(soundEffect);
    }
}
