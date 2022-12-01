using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKontrol : MonoBehaviour
{
    public GameObject flipModel;

    public float detectionTime;
    float startWalk;
    bool firstDetection;

    //Movement options
    public float runSpeed;
    public bool facingRight = true;

    float moveSpeed;
    bool running;

    Rigidbody myRB;
    Animator myAnim;
    Transform detectedPlayer;

    bool Detected;


    void Start()
    {
        myRB = GetComponentInParent<Rigidbody>();
        myAnim = GetComponentInParent<Animator>();

        running = false;
        Detected = false;
        firstDetection = false;
        moveSpeed = runSpeed;

        if (Random.Range(0, 10) > 5) Flip();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Detected)
        {
            if(detectedPlayer.position.x < transform.position.x && facingRight) Flip();
            else if (detectedPlayer.position.x > transform.position.x && !facingRight) Flip();
            if (!firstDetection)
            {
                startWalk = Time.time + detectionTime;
                firstDetection = true;
            }
        }
        if (Detected && !facingRight) myRB.velocity = new Vector3((moveSpeed * -1), myRB.velocity.y, 0);
        else if(Detected && facingRight) myRB.velocity = new Vector3(moveSpeed, myRB.velocity.y, 0);

        if(!running && Detected)
        {
            if (startWalk < Time.time)
            {
                moveSpeed = runSpeed;
                running = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !Detected)
        {
            Detected = true;
            detectedPlayer = other.transform;
            myAnim.SetBool("detected", Detected);
            if (detectedPlayer.position.x < transform.position.x && facingRight) Flip();
            else if (detectedPlayer.position.x > transform.position.x && !facingRight) Flip();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            firstDetection = false;
            running = false;
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = flipModel.transform.localScale;
        theScale.x *= -1;
        flipModel.transform.localScale = theScale;
    }
}
