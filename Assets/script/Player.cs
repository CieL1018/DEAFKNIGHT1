using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D myRB;
    Animator myAnim;

    bool facingRight;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));

        myRB.velocity = new Vector3(move * moveSpeed, myRB.velocity.y, 0);

        if (move > 0 && !facingRight) Flip();
        else if (move < 0 && facingRight) Flip();
    }
    
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
