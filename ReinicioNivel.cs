using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ReinicioNivel : MonoBehaviour
{

    [SerializeField] private GameObject menu;

    private PlayerCombat combateJugador;
    
    [SerializeField] AudioSource myAudio;
    public AudioClip speakSound;

    private void Start()
    {
        combateJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        combateJugador.MuerteJugador += AbrirMenu;
        myAudio = GetComponent<AudioSource>();
    }



    private void AbrirMenu(object sender, EventArgs e)
    {
        menu.SetActive(true);
        myAudio.PlayOneShot(speakSound);
    }


    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"), LayerMask.NameToLayer("Enemigos"), false);

    }
}
