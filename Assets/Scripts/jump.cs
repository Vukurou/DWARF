using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jump : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    private bool isJumping = false;
    private bool isWalking = false;
    private Vector3 spawnPoint;
    private bool isAlive = true;
    private bool canControl = true;

    // Reference to the Dwarf prefab
    public GameObject dwarfPrefab;

    public AudioClip jumpSound;
    public AudioClip moveSound;
<<<<<<< Updated upstream

    public AudioClip impaleSound;
    private AudioSource jumpAudio;
    private AudioSource moveAudio;

    private AudioSource impaleAudio;

=======
    public AudioClip screamSound;
    private AudioSource jumpAudio;
    private AudioSource moveAudio;
    private AudioSource screamAudio;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    private void Awake()
    {

        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spawnPoint = transform.position;

        jumpAudio = gameObject.AddComponent<AudioSource>();
        jumpAudio.playOnAwake = false;
        jumpAudio.clip = jumpSound;

        moveAudio = gameObject.AddComponent<AudioSource>();
        moveAudio.playOnAwake = false;
        moveAudio.clip = moveSound;

<<<<<<< Updated upstream
        impaleAudio = gameObject.AddComponent<AudioSource>();
        impaleAudio.playOnAwake = false;
        impaleAudio.clip = moveSound;
=======
        screamAudio = gameObject.AddComponent<AudioSource>();
        screamAudio.playOnAwake = false;
        screamAudio.clip = screamSound;
>>>>>>> Stashed changes
    }
    //Update is called once per frame
    void Update()
    {
        if (canControl && !isJumping && Input.GetKeyDown(KeyCode.W))
        {
            float jumpVelocity = 20f;
            rigidbody2D.velocity = Vector2.up * jumpVelocity;
            isJumping = true;

            jumpAudio.Play();
        }

        if (isAlive || canControl)
        {
            HandleMovement();
            HandleMovementAudio();
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
            if (!isJumping && !isWalking)
            {
                isWalking = true;
            }

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
            isWalking = false;
            // No keys pressed
            if (!isJumping)
            {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            }
        }
    }

    private void HandleMovementAudio()
    {
        if (isWalking && !moveAudio.isPlaying)
        {
            moveAudio.Play();
        }
        else if (!isWalking && moveAudio.isPlaying)
        {
            moveAudio.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("FallDetector"))
        {
            screamAudio.Play();
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
        

            impaleAudio.Play();

        }
        else if (collision.tag == "Checkpoint")
        {
            spawnPoint = transform.position;
        }
    }
}