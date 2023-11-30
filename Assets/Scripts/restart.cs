using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update()
    {
        RestartGame();
    }

    public void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SceneManager.LoadScene("Scene1");
        }
    }
}
