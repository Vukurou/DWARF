using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Impale : MonoBehaviour
{
    private Rigidbody2D rigidbodyDwarf;
    public GameObject platformPrefab;
    public GameObject dwarfPrefab;
    private Vector3 spawnPoint;

    private void Awake()
    {
        rigidbodyDwarf = GetComponent<Rigidbody2D>();
        spawnPoint = GameObject.Find("Dwarf").transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Dwarf>())
        {
            Instantiate(dwarfPrefab, spawnPoint, Quaternion.identity);
            rigidbodyDwarf.velocity = Vector2.zero;
            rigidbodyDwarf.bodyType = RigidbodyType2D.Static;

            // Set the game object's parent to the spike
            transform.SetParent(other.transform);

            // Instantiate the Platform object at the current position
            Instantiate(platformPrefab, transform.position, Quaternion.identity);

            // Destroy both the spike (parent) and the game object (this) after a delay
            Destroy(other.gameObject); // Destroy the spike
            Destroy(gameObject); // Destroy this game object

        }
    }
}

