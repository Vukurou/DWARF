using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDownUp : MonoBehaviour
{
    public float distance = 1.5f; // Distance to move up and down
    public float speed = 0.5f; // Speed of the movement

    private Vector3 startPosition;
    private bool movingUp = false;

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
