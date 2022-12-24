using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public Rigidbody2D rb;
    public float knockBackForce = 10;
    public float knockBackForceUp = 2;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);   
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            playerDead();
        }
        healthBar.setHealth(currentHealth);
    }

    public void playerDead()
    {
        Destroy(gameObject);
    }

    /*public float knockBack(){
        Transform attacker = getCloseDamageSource();
        Vector2 knockbackDirection = new Vector2(transform.position.x - attacker.transform.position.x, 0);
        rb.velocity = new Vector2(knockbackDirection.x, knockBackForceUp) * knockBackForce;
    }

    public Transform getCloseDamageSource(){
        GameObject[] DamageSources = GameObject.FindgameObjectWithTag("Enemy");
        float closeDistanz = Mathf.Infinity;
        Transform currentClosesDamageSource = null;

        foreach (GameObject go in DamageSources)
        {
            float CurrentDitanz;
            CurrentDitanz = Vector3.Distance(transform.position, go.transform.position);
            if(CurrentDitanz < closeDistanz){
                closeDistanz = CurrentDitanz;
                currentClosesDamageSource = go.transform;
            }
        }
        return currentClosesDamageSource;
    }*/
}
