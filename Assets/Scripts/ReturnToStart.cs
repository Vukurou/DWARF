using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    void Update()
    {
        ReturnStart();
    }

    public void ReturnStart()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SceneManager.LoadScene("StartScreen");
        }
    }
}
