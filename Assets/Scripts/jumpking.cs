using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class JumpKing : MonoBehaviour
{
    private Rigidbody2D rigidbody2DKing;
    private BoxCollider2D boxCollider2DKing;
    private bool isJumpingKing = false;
    private Vector3 spawnPoint;
    private bool isAliveKing = true;

    public GameObject dwarfKing;

    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2DKing = GetComponent<Rigidbody2D>();
        boxCollider2DKing = GetComponent<BoxCollider2D>();
        spawnPoint = transform.position;
        gameObject.SetActive(false);
        Debug.Log("JumpKing Awake");
    }
    //Update is called once per frame
    void Update()
    {
        bool onlyPlatforms = GameObject.FindGameObjectsWithTag("Spike").Length == 0;
        Debug.Log("onlyPlatforms: " + onlyPlatforms);

        if (onlyPlatforms && dwarfKing != null && !dwarfKing.activeSelf)
        {
            dwarfKing.SetActive(true); // Reactivate DwarfKing when only platforms are present
        }

        if (!isJumpingKing && Input.GetKeyDown(KeyCode.W))
        {
            float jumpVelocity = 20f;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            isJumpingKing = true;
        }

        if (isAliveKing)
        {
            HandleMovementKing();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isJumpingKing = false;
        }
    }
    private void HandleMovementKing()
    {
        float moveSpeed = 7f;
        float midAirControl = 2f;
        if (Input.GetKey(KeyCode.D))
        {
            if (!isJumpingKing)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(+moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity += new Vector2(+moveSpeed * midAirControl * Time.deltaTime, 0);
                GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Clamp(GetComponent<Rigidbody2D>().velocity.x, -moveSpeed, +moveSpeed), GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        else
        {
            // No keys pressed
            if (!isJumpingKing)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("FallDetector"))
        {
            //GAME OVER
        }
        else if (collision.gameObject.CompareTag("Spike"))
        {
            // Set isAlive to false to stop movement
            isAliveKing = false;

            if (TryGetComponent<Rigidbody>(out var rb))
            {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }

        }
    }
}