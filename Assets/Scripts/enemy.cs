using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject dwarfPrefab;
    private Vector3 spawnPoint;
    //private Rigidbody2D rigidbody2DEnemy;

    private void Awake()
    {
        //rigidbody2DEnemy = GetComponent<Rigidbody2D>();
        spawnPoint = GameObject.Find("Dwarf").transform.position;
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
            SceneManager.LoadScene("GameOver");
        }
    }
}


