using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMover : MonoBehaviour
{
    private Rigidbody2D rigidbodyspike;
    public float distance = 1.5f; // Distance to move left and right
    public float speed = 0.5f; // Speed of the movement

    public Rigidbody2D rigidbodyDwarf = null;

    private Vector3 startPosition;
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyspike = gameObject.GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            if (transform.position.x < startPosition.x + distance)
            {
                //neu
                transform.position += Vector3.right * speed * Time.deltaTime;
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
                //neu
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else
            {
                movingRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        float height = collision.collider.bounds.size.y;
        //süsch wenns ned funktioniert duesch 0.1 chli wiiter uufe.
        if(collision.transform.position.y - height > transform.position.y - 0.4f)
        {
            Debug.Log("collision.transform.position.y: " + collision.transform.position.y);
            Debug.Log("transform.position.y: " + transform.position.y);
            
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        collision.transform.SetParent(null);
    }
}