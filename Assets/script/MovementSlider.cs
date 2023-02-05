using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementSlider : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject Player;
    [SerializeField] private Slider slider;
    [SerializeField] private float movementSpeed;

    Animator myAnim;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float movement = slider.value;

        Player.transform.position += new Vector3(movement,0,0) * movementSpeed * Time.deltaTime;

        if(slider.value == 0)
        {
            Player.transform.rotation = Player.transform.rotation;
            myAnim.SetBool("moving", false);
        }else if(slider.value < 0)
        {   
            Player.transform.rotation = Quaternion.Euler(0,0,0);
            myAnim.SetBool("moving", true);
        }else if(slider.value > 0)
        {
            Player.transform.rotation = Quaternion.Euler(0,180,0);
            myAnim.SetBool("moving", true);
        }

    }

    public void resetSlider()
    {
        slider.value = 0;
    }
}
