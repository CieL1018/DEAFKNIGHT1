using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject character;

    private Rigidbody myRB;
    private float ScreenWidth;

    void Start()
    {
        ScreenWidth = Screen.width;
        myRB = character.GetComponent<Rigidbody>();
    }

    void Update()
    {
        int i = 0;
        while(i < Input.touchCount)
        {
            if(Input.GetTouch(1).position.x > ScreenWidth / 2)
            {
                runCharacter(1.0f);
            }
            if(Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                runCharacter(-1.0f);
            }
        }
    }
    void FixedUpdate()
    {
#if UNITY_EDITOR
        runCharacter(Input.GetAxis("Horizontal"));
#endif
    }
    private void runCharacter(float horizontalInput)
    {
        myRB.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));

    }
}
