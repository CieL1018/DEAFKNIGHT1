using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    GameManger gameManger;
    Rigidbody2D myRB;
    Animator myAnim;
 
    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("Player");
        gameManger = gameController.GetComponent<GameManger>();
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

    }

    void Update()
    {
        transform.Translate(gameManger.moveVector * gameManger.speed * Time.deltaTime); 
    }

    void FixedUpdate()
    {
        myAnim.SetBool("walk", true);
    }
}
