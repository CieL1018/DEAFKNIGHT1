using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int fullHealth = 100;
    public int latestHealth;

    public HealthBar Bar;
    void Start()
    {
        latestHealth = fullHealth;
        Bar.SetMaxHealth(fullHealth);  
    }

    public void addDamage(int damage)
    {
        latestHealth -= damage;
        if(latestHealth <= 0)
        {
            makeDead();
        }
        Bar.setHealth(latestHealth);
    }

    public void makeDead()
    {
        Destroy(gameObject);
    }
}
