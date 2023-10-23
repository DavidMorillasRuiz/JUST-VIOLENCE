using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{

    public GameObject Shield;
    [SerializeField] private AudioClip poderEscudo;

    // Start is called before the first frame update
    void Start()
    {
        
        Shield.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioController.Instance.PlaySound(poderEscudo);
            ActivarEscudo();
            StartCoroutine(DesactivarEscudo());
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }



    void ActivarEscudo()
    {
        Shield.SetActive(true);
        
    }

    private IEnumerator DesactivarEscudo()
    {

        yield return new WaitForSeconds(4);
        Shield.SetActive(false);

    }




}
