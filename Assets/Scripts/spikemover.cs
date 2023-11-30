using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMover : MonoBehaviour
{
    private Rigidbody2D rigidbodyspike;
    public float distance = 1.5f; // Distance to move left and right
    public float speed = 0.5f; // Speed of the movement

    private Vector3 startPosition;
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyspike = gameObject.GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movingRight)
        {
            if (transform.position.x < startPosition.x + distance)
            {
                rigidbodyspike.velocity = Vector2.right * speed;
            }
            else
            {
                movingRight = false;
            }
        }
        else
        {
            if (transform.position.x > startPosition.x - distance)
            {
                rigidbodyspike.velocity = Vector2.left * speed;
            }
            else
            {
                movingRight = true;
            }
        }
    }
}
