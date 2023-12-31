using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy4 : MonoBehaviour
{
    public GameObject dwarfPrefab;
    private Vector3 spawnPoint;
    
    private void Awake()
    {
        spawnPoint = GameObject.Find("4Dwarf").transform.position;
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


