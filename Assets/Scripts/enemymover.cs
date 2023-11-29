using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymover : MonoBehaviour
{
    public float distance = 1.0f; // Distance to move left and right
    public float speed = 1.0f; // Speed of the movement

    private Vector3 startPosition;
    private bool movingUp = true;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingUp)
        {
            if (transform.position.y < startPosition.y + distance)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            else
            {
                movingUp = false;
            }
        }
        else
        {
            if (transform.position.y > startPosition.y - distance)
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
            else
            {
                movingUp = true;
            }
        }
    }
}
