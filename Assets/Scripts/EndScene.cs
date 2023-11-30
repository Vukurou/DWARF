using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    // Bei Kollision neue Szene laden
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DwarfKing"))
        {
            SceneManager.LoadScene("EndGameScreen");
            Debug.Log("detected");
        }
    }
}
