using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint1 : MonoBehaviour
{
    // Bei Kollision neue Szene laden
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zwerg"))
        {
            SceneManager.LoadScene("Scene2");
            Debug.Log("detected");
        }
    }
}
