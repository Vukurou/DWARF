using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject dwarfPrefab;
    private Vector3 spawnPoint;

    public delegate void GameOverDelegate();
    public static event GameOverDelegate OnGameOver;
    
    private void Awake()
    {
        spawnPoint = transform.position;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object collided with has the tag "Dwarf"
        if (collision.collider.CompareTag("Zwerg"))
        {
            Instantiate(dwarfPrefab, spawnPoint, Quaternion.identity);
            // Destroy the collided dwarf
            Destroy(collision.collider.gameObject);
        }
            else if (collision.collider.CompareTag("DwarfKing"))
        {
            // Trigger Game Over
            OnGameOver?.Invoke();
        }
    }
}

