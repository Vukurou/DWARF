using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jump : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    private bool isJumping = false;
    private Vector3 spawnPoint;
    private bool isAlive = true;
    private bool canControl = true;

    // Reference to the Dwarf prefab
    public GameObject dwarfPrefab;

    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spawnPoint = transform.position;
    }
    //Update is called once per frame
    void Update()
    {
        if (canControl && !isJumping && Input.GetKeyDown(KeyCode.W))
        {
            float jumpVelocity = 20f;
            rigidbody2D.velocity = Vector2.up * jumpVelocity;
            isJumping = true;
        }

        if (isAlive || canControl)
        {
            HandleMovement();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isJumping = false;
        }
    }
    private void HandleMovement()
    {
        float moveSpeed = 7f;
        float midAirControl = 2f;
        if (canControl && Input.GetKey(KeyCode.D))
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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("FallDetector"))
        {
            canControl = false;
            Instantiate(dwarfPrefab, spawnPoint, Quaternion.identity);
        }
        else if (collision.gameObject.CompareTag("Spike"))
        {
            // Set isAlive to false to stop movement
            isAlive = false;

            if (TryGetComponent<Rigidbody>(out var rb))
            {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }

        }
        else if (collision.tag == "Checkpoint")
        {
            spawnPoint = transform.position;
        }
    }
}