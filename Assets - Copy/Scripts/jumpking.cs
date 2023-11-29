using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpKing : MonoBehaviour
{
    // [SerializeField] private GameObject robotPlayer;
    private new Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    private bool isJumping = false;
    private bool isAlive = true;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    //Update is called once per frame
    void Update()
    {
        if (!isJumping && Input.GetKeyDown(KeyCode.W))
        {
            float jumpVelocity = 20f;
            rigidbody2D.velocity = Vector2.up * jumpVelocity;
            isJumping = true;
        }

        if (isAlive)
        {
            HandleMovement();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Plattform"))
        {
            isJumping = false;
        }
    }
    private void HandleMovement()
    {
        float moveSpeed = 7f;
        float midAirControl = 2f;
        if (Input.GetKey(KeyCode.D))
        {
            if (!isJumping)
            {
                rigidbody2D.velocity = new Vector2(+moveSpeed, rigidbody2D.velocity.y);
            }
            else
            {
                rigidbody2D.velocity += new Vector2(+moveSpeed * midAirControl * Time.deltaTime, 0);
                rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, -moveSpeed, +moveSpeed), rigidbody2D.velocity.y);
            }
        }
        else
        {
            // No keys pressed
            if (!isJumping)
            {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the GameObject it collided with has the tag "Spike"
        if (collision.gameObject.tag == "Spike")
        {
// Set isAlive to false to stop movement
            isAlive = false;

            // Additional logic to handle the GameObject being "not alive"
            // For example, disabling Rigidbody dynamics:
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }
        }
    }
}