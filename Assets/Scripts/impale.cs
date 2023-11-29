using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Impale : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    public GameObject platformPrefab;
    
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Spike>())
        {
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.bodyType = RigidbodyType2D.Static;

            // Set the game object's parent to the spike
            transform.SetParent(other.transform);

            // Instantiate the Platform object at the current position
            Instantiate(platformPrefab, other.transform.position, Quaternion.identity);

            // Destroy both the spike (parent) and the game object (this) after a delay
            Destroy(other.gameObject); // Destroy the spike
            Destroy(gameObject); // Destroy this game object
        }
    }
}

