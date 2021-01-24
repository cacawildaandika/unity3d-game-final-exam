using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public GameObject healthBarUI;
    public Slider slider;

    public void decreaseHealth(float amount)
    {
        currentHealth -= amount;
    }

    public void increaseHealth(float amount)
    {
        currentHealth += amount;
    }


    void Start()
    {
        currentHealth = maxHealth;
        slider.value = CalculateHealth();
    }

    
    void Update()
    {
        slider.value = CalculateHealth();

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        if(currentHealth < 0)
        {
            currentHealth = 0;
        }

        if(currentHealth == 0)
        {
            SceneManager.LoadScene("DieScene");
            
        }
    }

    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }
}
