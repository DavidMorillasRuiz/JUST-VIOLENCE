using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
	[SerializeField] Slider slider;
    [SerializeField] GameObject Cara1;
    [SerializeField] GameObject Cara2;
    [SerializeField] GameObject Cara3;
    public Gradient gradient;
    public Image fill;
    private void Start()
    {
        Cara1.SetActive(true);
        Cara2.SetActive(false);
        Cara3.SetActive(false);
    }
    private void Update()
    {

        slider.value = GameManager.Instance.playerHealth;
        fill.color = gradient.Evaluate(0.5f) ;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        if (GameManager.Instance.playerHealth <= 50)
        {
            Cara1.SetActive(false);
            Cara2.SetActive(true);
            
        }
       
        if(GameManager.Instance.playerHealth <=10)
        {
            Cara2.SetActive(false);
            Cara3.SetActive(true);
        }
        
        if(GameManager.Instance.playerHealth <= 0)
        {
            // Reiniciamos el nivel.
            SceneManager.LoadScene(1);
        }
    }

}
