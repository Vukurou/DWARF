using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnEnable()
    {
        Enemy.OnGameOver += HandleGameOver;
    }

    private void OnDisable()
    {
        Enemy.OnGameOver -= HandleGameOver;
    }

    private void HandleGameOver()
    {
        // Logic to handle game over, e.g., show game over screen, stop the game, etc.
        Debug.Log("Game Over");
    }
}
