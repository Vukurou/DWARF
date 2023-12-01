using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BgMusic : MonoBehaviour
{
    private AudioSource audioSource; // Moved the declaration here
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        // Your update logic here
    }
}