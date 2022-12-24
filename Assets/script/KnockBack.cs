using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;

    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D Player = other.GetComponent<Rigidbody2D>();
            if(Player != null){
                Player.isKinematic = false;
                Vector2 difference = Player.transform.position - transform.position;
                difference = difference.normalized * thrust;
                Player.AddForce(difference, ForceMode2D.Impulse);
                Player.isKinematic = true;
            }
        }
    }
}