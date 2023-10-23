using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("There is no GameManager");
            }
            return instance;
        }
    }

    [Header("PlayerStats")]
    public float playerHealth = 100f;
    public float maxHealth;
    public int attackDamage = 50;

    public static bool isGameOver;
    public GameObject panel;
    
    

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        isGameOver= false;
    }

    // Update is called once per frame
    void Update()
    {
       if(isGameOver)
        {
            panel.SetActive(true);
        }
    }

    public void PerderVida()
    {
        
        playerHealth -= 5;
        

        if (playerHealth == 0)
        {
            // Reiniciamos el nivel.
            isGameOver= true;
        }

        
    }

    public void PerderVidaR()
    {

        playerHealth -= 10;


        if (playerHealth == 0)
        {
            // Reiniciamos el nivel.
            SceneManager.LoadScene(0);
        }


    }

    public void PerderVidaB()
    {

        playerHealth -= 10;


        if (playerHealth == 0)
        {
            // Reiniciamos el nivel.
            SceneManager.LoadScene(0);
        }


    }




}
