using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    Rigidbody myRB;
    Animator myAnim;

    bool facingRight;
    void Start()
    {
        myRB = gameObject.GetComponent<Rigidbody>();
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

        myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);

        if(move != 0)
        {
            myRB.AddForce(new Vector2(move * runSpeed, 0f));
        }

        if(move > 0 && !facingRight)
        {
            Flip();
        }

        if (move < 0 && facingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
