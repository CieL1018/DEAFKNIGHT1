using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private float CurrentBlood;

    private void Awake()
    {
        CurrentBlood = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        CurrentBlood -= _damage;
        if(CurrentBlood <= 0)
        {
            playerDead();
        }
    }

    public void playerDead()
    {
        Destroy(gameObject);
    }
}
