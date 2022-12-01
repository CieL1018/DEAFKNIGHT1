using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    float lenght, startX, startY;
    public GameObject player;

    public float parallaxX;

    public float parallaxY;
    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (player.transform.position.x * (1 - parallaxX));
        float distX = (player.transform.position.x * parallaxX);
        float distY = (player.transform.position.y * parallaxX);
        transform.position = new Vector3(startX + distX, startY + distY, transform.position.z);

        if (temp > startX + lenght) startX += lenght;
        else if (temp < startX - lenght) startX -= lenght;

    }
}
