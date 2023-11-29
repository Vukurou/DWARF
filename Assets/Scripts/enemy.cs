using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigidbodyDwarf;
    private Vector3 spawnPoint;
    
    private void Awake()
    {
        rigidbodyDwarf = GetComponent<Rigidbody2D>();
        spawnPoint = transform.position;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object collided with has the tag "Dwarf"
        if (collision.collider.CompareTag("Zwerg"))
        {
            // Destroy the collided dwarf
            Destroy(collision.collider.gameObject);
        }
    }
}


