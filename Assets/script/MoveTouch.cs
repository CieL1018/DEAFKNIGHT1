using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTouch : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 target;

    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.x = transform.position.x;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
