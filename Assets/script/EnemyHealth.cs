using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float fullHealth;
    float currentHealth;


    public Slider playerHealthSlider;
    void Start()
    {
        currentHealth = fullHealth;
    }
    void Update()
    {

    }

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void makeDead()
    {
        Destroy(gameObject);
    }
}
